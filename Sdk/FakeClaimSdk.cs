namespace ClaimBridge.Sdk;

public class FakeClaimSdk
{
    public string SendClaim(string userId)
    {

        if(userId == "error")
    {
        throw new Exception(
            "SDK Error");
    }

        return $"SDK Send Success : {userId}";
    }
}