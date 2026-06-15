using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClaimBridge.Services;

public class SignatureService
{
    private readonly CertService _certService;

    public SignatureService(
        CertService certService)
    {
        _certService = certService;
    }

    public string Sign(string message)
    {
        var cert =
            _certService.GetLocalhostCertificate();

        if (cert == null)
            throw new Exception(
                "localhost証明書が見つかりません");

        var rsa = cert.GetRSAPrivateKey();

        if (rsa == null)
            throw new Exception(
                "秘密鍵が見つかりません");

        var bytes =
            Encoding.UTF8.GetBytes(message);

        var signature =
            rsa.SignData(
                bytes,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

        return Convert.ToBase64String(
            signature);
    }

    public bool Verify(
        string message,
        string signature)
    {
        var cert =
            _certService.GetLocalhostCertificate()
            ?? throw new InvalidOperationException(
                "localhost証明書が見つかりません");

        var rsa = cert.GetRSAPublicKey()
            ?? throw new InvalidOperationException(
                "公開鍵が取得できません");

        var bytes =
            Encoding.UTF8.GetBytes(message);

        var signatureBytes =
            Convert.FromBase64String(signature);

        return rsa.VerifyData(
            bytes,
            signatureBytes,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);
    }
}