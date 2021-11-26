using System;
using System.IO;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Data.Runtime;
using UGF.Database.Runtime;
using UGF.Module.Controllers.Runtime;

namespace UGF.Module.Database.Runtime
{
    public class DatabaseLoaderController : ControllerDescribed<DatabaseLoaderControllerDescription>, IDatabaseLoaderController
    {
        protected IControllerModule ControllerModule { get; }
        protected IDatabaseModule DatabaseModule { get; }

        public DatabaseLoaderController(DatabaseLoaderControllerDescription description, IApplication application) : base(description, application)
        {
            ControllerModule = Application.GetModule<IControllerModule>();
            DatabaseModule = Application.GetModule<IDatabaseModule>();
        }

        public T Read<T>(string id) where T : class, IDatabase
        {
            return (T)Read(id);
        }

        public IDatabase Read(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            var controller = ControllerModule.Provider.Get<IDataLoaderController>(Description.DataLoaderControllerId);
            string path = OnCombinePath(id);
            var database = controller.Read<IDatabase>(path);

            return database;
        }

        public async Task<T> ReadAsync<T>(string id) where T : class, IDatabase
        {
            return (T)await ReadAsync(id);
        }

        public async Task<IDatabase> ReadAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            var controller = ControllerModule.Provider.Get<IDataLoaderController>(Description.DataLoaderControllerId);
            string path = OnCombinePath(id);
            var database = await controller.ReadAsync<IDatabase>(path);

            return database;
        }

        public void Write(string id, IDatabase database)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (database == null) throw new ArgumentNullException(nameof(database));

            var controller = ControllerModule.Provider.Get<IDataLoaderController>(Description.DataLoaderControllerId);
            string path = OnCombinePath(id);

            controller.Write(path, database);
        }

        public async Task WriteAsync(string id, IDatabase database)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (database == null) throw new ArgumentNullException(nameof(database));

            var controller = ControllerModule.Provider.Get<IDataLoaderController>(Description.DataLoaderControllerId);
            string path = OnCombinePath(id);

            await controller.WriteAsync(path, database);
        }

        protected virtual string OnCombinePath(string id)
        {
            return Path.Combine(Description.Path, id);
        }
    }
}
