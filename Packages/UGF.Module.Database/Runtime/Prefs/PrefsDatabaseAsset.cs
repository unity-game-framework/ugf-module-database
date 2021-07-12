using UGF.Database.Runtime;
using UGF.Database.Runtime.Prefs;
using UnityEngine;

namespace UGF.Module.Database.Runtime.Prefs
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Database/Database Prefs", order = 2000)]
    public class PrefsDatabaseAsset : DatabaseBuilderAsset
    {
        protected override IDatabase OnBuild()
        {
            return new PrefsDatabase();
        }
    }
}
