using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Database.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Database.Runtime
{
    public class DatabaseModule : ApplicationModule<DatabaseModuleDescription>, IDatabaseModule
    {
        public IProvider<string, IDatabase> Provider { get; }

        IDatabaseModuleDescription IDatabaseModule.Description { get { return Description; } }

        public DatabaseModule(DatabaseModuleDescription description, IApplication application) : this(description, application, new Provider<string, IDatabase>())
        {
        }

        public DatabaseModule(DatabaseModuleDescription description, IApplication application, IProvider<string, IDatabase> provider) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (KeyValuePair<string, IDatabaseBuilder> pair in Description.Databases)
            {
                IDatabase database = pair.Value.Build();

                Provider.Add(pair.Key, database);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Provider.Clear();
        }
    }
}
