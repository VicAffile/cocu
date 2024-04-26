using System.Configuration;
using System.Data;
using System.Windows;

using Cocu.Data;

namespace Cocu
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
