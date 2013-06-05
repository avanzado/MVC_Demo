using Framework;
using Framework.Data;
using Framework.Infrastructure;
using System;

namespace DataAccess.Data
{
    public class EfStartUpTask : IStartupTask
    {
        public void Execute()
        {
            var settings =  (new DataSettingsManager()).LoadSettings();
            if (settings != null && settings.IsValid())
            {
                var provider = (new EfDataProviderManager(settings)).LoadDataProvider();
                if (provider == null)
                    throw new Exception("No EfDataProvider found");
                ((IEfDataProvider)provider).SetDatabaseInitializer();
            }
        }
    }
}
