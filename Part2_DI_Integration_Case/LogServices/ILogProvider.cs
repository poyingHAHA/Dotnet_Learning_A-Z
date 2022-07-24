using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices
{
    public interface ILogProvider
    {
        public void LogError(string msg);
        public void LogInfo(string msg);
    }
}