namespace ClaimBridge.Services;
using ClaimBridge.Sdk;

public class ClaimService
{
    private readonly FakeClaimSdk _sdk;

    public ClaimService(
        FakeClaimSdk sdk)
    {
        _sdk = sdk;
    }

    public string GetStatus()
    {
        return "service called";
    }

    public string Send(string userId)
    {
        return _sdk.SendClaim(userId);
    }
}