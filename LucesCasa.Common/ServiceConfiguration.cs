namespace LucesCasa.Common
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public static string ConnectionString { get; set; }
        public static byte[] Key { get; set; }
        public static string ModuleUser { get; set; }
        public static string ModulePassword { get; set; }
    }
}