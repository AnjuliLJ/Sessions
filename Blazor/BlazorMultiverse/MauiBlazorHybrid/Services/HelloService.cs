namespace MauiBlazorHybrid.Services;

public class HelloService : IHelloService
{
    public string Hello(string source)
    {
        return $"Hello from {source}";
    }
}
