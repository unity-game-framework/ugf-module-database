using System.Threading.Tasks;
using UGF.Database.Runtime;
using UGF.Module.Controllers.Runtime;

namespace UGF.Module.Database.Runtime
{
    public interface IDatabaseLoaderController : IController
    {
        T Read<T>(string id) where T : class, IDatabase;
        IDatabase Read(string id);
        Task<T> ReadAsync<T>(string id) where T : class, IDatabase;
        Task<IDatabase> ReadAsync(string id);
        void Write(string id, IDatabase database);
        Task WriteAsync(string id, IDatabase database);
    }
}
