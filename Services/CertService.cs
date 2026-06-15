using System.Security.Cryptography.X509Certificates;
using ClaimBridge.Models;
namespace ClaimBridge.Services;

public class CertService
{
    public List<CertificateInfo> GetCertificates()
    {
        var store = new X509Store(
            StoreName.My,
            StoreLocation.CurrentUser);

        store.Open(OpenFlags.ReadOnly);

        var result = store.Certificates
        .Select(x => new CertificateInfo
            {
                Subject = x.Subject,
                Issuer = x.Issuer,
                Thumbprint = x.Thumbprint,
                NotAfter = x.NotAfter,
                HasPrivateKey = x.HasPrivateKey
            }).ToList();

        store.Close();

        return result;
    }

    public X509Certificate2? GetLocalhostCertificate()
    {
        var store = new X509Store(
            StoreName.My,
            StoreLocation.CurrentUser);

        store.Open(OpenFlags.ReadOnly);

        var cert = store.Certificates
            .Cast<X509Certificate2>()
            .FirstOrDefault(x =>
                x.Subject.Contains("localhost"));

        store.Close();

        return cert;
    }
}