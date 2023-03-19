using Microsoft.EntityFrameworkCore;

namespace ThinkBridge.ShopBridge.Data.Tests.Fixture
{
    public class ShopBridgeBdContextFixture : IDisposable
    {
        public readonly ShopBridgeDbContext ShopBridgeDbContext;

        public ShopBridgeBdContextFixture()
        {
            var options = new DbContextOptionsBuilder<ShopBridgeDbContext>()
                .UseInMemoryDatabase("shopbridgedatabase")
                .Options;

            ShopBridgeDbContext = new ShopBridgeDbContext(options);
        }

        public void Dispose()
        {
            ShopBridgeDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
