namespace Sazman.Tests
{
    public class TestClientProvider : IDisposable
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7249/api/");
            Client.Timeout = new TimeSpan(0, 0, 30);
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
