namespace LucesCasa.Common
{
    public interface IServiceConfiguration
    {
        public static string ConnectionString { get; set; }
        public static byte[] Key { get; set; }
        public static string ModuleUser { get; set; }
        public static string ModulePassword { get; set; }
    }
}
