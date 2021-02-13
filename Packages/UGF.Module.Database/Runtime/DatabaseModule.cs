using UGF.Application.Runtime;

namespace UGF.Module.Database.Runtime
{
    public class DatabaseModule : ApplicationModule<DatabaseModuleDescription>, IDatabaseModule
    {
        IDatabaseModuleDescription IDatabaseModule.Description { get { return Description; } }

        public DatabaseModule(DatabaseModuleDescription description, IApplication application) : base(description, application)
        {
        }
    }
}
