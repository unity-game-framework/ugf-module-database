using UGF.Application.Runtime;
using UGF.Data.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Module.Database.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Data/Database Loader Controller", order = 2000)]
    public class DatabaseLoaderControllerAsset : ControllerDescribedAsset<DatabaseLoaderController, DatabaseLoaderControllerDescription>
    {
        [AssetGuid(typeof(DataLoaderControllerAsset))]
        [SerializeField] private string m_dataLoaderController;
        [SerializeField] private string m_path = "Databases";

        public string DataLoaderController { get { return m_dataLoaderController; } set { m_dataLoaderController = value; } }
        public string Path { get { return m_path; } set { m_path = value; } }

        protected override DatabaseLoaderControllerDescription OnBuildDescription()
        {
            var description = new DatabaseLoaderControllerDescription
            {
                DataLoaderControllerId = m_dataLoaderController,
                Path = m_path
            };

            return description;
        }

        protected override DatabaseLoaderController OnBuild(DatabaseLoaderControllerDescription description, IApplication application)
        {
            return new DatabaseLoaderController(description, application);
        }
    }
}
