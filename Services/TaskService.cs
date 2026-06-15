namespace ClaimBridge.Services;

public class TaskService
{
    public async Task<string> GetStatusAsync()
    {
        Console.WriteLine(
        $"Service Start {DateTime.Now:HH:mm:ss.fff}");

        await Task.Delay(5000); // 5秒待機

        Console.WriteLine(
        $"Service End {DateTime.Now:HH:mm:ss.fff}");

        return "async done";
    }

    public string GetStatusSync()
    {
        Console.WriteLine(
        $"Service Start {DateTime.Now:HH:mm:ss.fff}");

        Thread.Sleep(5000); // 5秒待機

        Console.WriteLine(
        $"Service End {DateTime.Now:HH:mm:ss.fff}");
        
        return "sync done";
    }
}