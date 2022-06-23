using eShop.Persistance;

namespace eShop.Tests.Common
{
    public class TestBase : IDisposable
    {
        protected readonly ApplicationDbContext Context;

        public TestBase()
        {
            Context = ApplicationContextFactory.Create();
        }

        public void Dispose()
        {
            ApplicationContextFactory.Destroy(Context);
        }
    }
}
