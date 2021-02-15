using UGF.Database.Runtime;
using UGF.Database.Runtime.Prefs;
using UnityEngine;

namespace UGF.Module.Database.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestDatabaseAsset")]
    public class TestDatabaseAsset : DatabaseBuilderAsset
    {
        protected override IDatabase OnBuild()
        {
            return new PrefsDatabase();
        }
    }
}
