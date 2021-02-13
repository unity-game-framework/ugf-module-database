using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Database.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Database/Database Module", order = 2000)]
    public class DatabaseModuleAsset : ApplicationModuleAsset<IDatabaseModule, DatabaseModuleDescription>
    {
        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new DatabaseModuleDescription();

            return description;
        }

        protected override IDatabaseModule OnBuild(DatabaseModuleDescription description, IApplication application)
        {
            return new DatabaseModule(description, application);
        }
    }
}
