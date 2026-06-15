namespace ClaimBridge.Models;

public class CertificateInfo
{
    public string Subject { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Thumbprint { get; set; } = "";
    public DateTime NotAfter { get; set; }
}