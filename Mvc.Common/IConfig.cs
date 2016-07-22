namespace Mvc.Common
{
    public interface IConfig
    {
        string Environment { get; }
        string Version { get; }
    }
}