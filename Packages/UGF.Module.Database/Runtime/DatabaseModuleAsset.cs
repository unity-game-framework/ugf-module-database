using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Module.Database.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Database/Database Module", order = 2000)]
    public class DatabaseModuleAsset : ApplicationModuleAsset<IDatabaseModule, DatabaseModuleDescription>
    {
        [SerializeField] private List<AssetReference<DatabaseBuilderAsset>> m_databases = new List<AssetReference<DatabaseBuilderAsset>>();

        public List<AssetReference<DatabaseBuilderAsset>> Databases { get { return m_databases; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new DatabaseModuleDescription
            {
                RegisterType = typeof(IDatabaseModule)
            };

            for (int i = 0; i < m_databases.Count; i++)
            {
                AssetReference<DatabaseBuilderAsset> reference = m_databases[i];

                description.Databases.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override IDatabaseModule OnBuild(DatabaseModuleDescription description, IApplication application)
        {
            return new DatabaseModule(description, application);
        }
    }
}
