﻿using log4net;

namespace Mvc.Common.Service
{
    public class AppService : IAppService
    {
        public AppService(IConfig config, ILog log)
        {
            Configuration = config;
            Log = log;
        }

        public IConfig Configuration { get; }

        public ILog Log { get; }
    }
}
