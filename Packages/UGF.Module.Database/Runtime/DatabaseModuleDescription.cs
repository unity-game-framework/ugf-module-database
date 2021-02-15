using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Database.Runtime;

namespace UGF.Module.Database.Runtime
{
    public class DatabaseModuleDescription : ApplicationModuleDescription, IDatabaseModuleDescription
    {
        public Dictionary<string, IDatabaseBuilder> Databases { get; } = new Dictionary<string, IDatabaseBuilder>();

        IReadOnlyDictionary<string, IDatabaseBuilder> IDatabaseModuleDescription.Databases { get { return Databases; } }
    }
}
