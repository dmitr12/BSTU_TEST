﻿using log4net;
using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace GitHubAutomation.Log
{
    class Logger
    {
        static ILog log = LogManager.GetLogger("LOG");
        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

    }
}
