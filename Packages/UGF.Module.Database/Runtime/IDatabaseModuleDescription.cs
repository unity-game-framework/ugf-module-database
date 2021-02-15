using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Database.Runtime;

namespace UGF.Module.Database.Runtime
{
    public interface IDatabaseModuleDescription : IApplicationModuleDescription
    {
        IReadOnlyDictionary<string, IDatabaseBuilder> Databases { get; }
    }
}
