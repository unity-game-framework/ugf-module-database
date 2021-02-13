using UGF.Application.Runtime;

namespace UGF.Module.Database.Runtime
{
    public interface IDatabaseModule : IApplicationModule
    {
        new IDatabaseModuleDescription Description { get; }
    }
}
