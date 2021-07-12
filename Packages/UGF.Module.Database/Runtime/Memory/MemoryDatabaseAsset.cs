using UGF.Database.Runtime;
using UGF.Database.Runtime.Memory;
using UnityEngine;

namespace UGF.Module.Database.Runtime.Memory
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Database/Database Memory", order = 2000)]
    public class MemoryDatabaseAsset : DatabaseBuilderAsset
    {
        protected override IDatabase OnBuild()
        {
            return new MemoryDatabase();
        }
    }
}
