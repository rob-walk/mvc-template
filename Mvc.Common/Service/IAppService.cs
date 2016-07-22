using log4net;

namespace Mvc.Common.Service
{
    public interface IAppService
    {
        IConfig Configuration { get; }
        ILog Log { get; }
    }
}
