using UGF.Application.Runtime;
using UGF.Database.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Database.Runtime
{
    public interface IDatabaseModule : IApplicationModule
    {
        new IDatabaseModuleDescription Description { get; }
        IProvider<string, IDatabase> Provider { get; }
    }
}
