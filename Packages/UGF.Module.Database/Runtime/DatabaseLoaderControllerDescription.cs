using UGF.Module.Controllers.Runtime;

namespace UGF.Module.Database.Runtime
{
    public class DatabaseLoaderControllerDescription : ControllerDescription
    {
        public string DataLoaderControllerId { get; set; }
        public string Path { get; set; }
    }
}
