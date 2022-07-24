using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SystemServices
{
    public class Test2
    {
         private readonly ILogger<Test2> logger;

        public Test2(ILogger<Test2> logger)
        {
            this.logger = logger;
        }

        public void Test()
        {
            logger.LogDebug("開始執行FTP同步");
            logger.LogDebug("連接FTP成功");
            logger.LogWarning("查找數據失敗, 重試...");
            logger.LogWarning("查找數據失敗, 重試第二次...");
            logger.LogError("查找數據失敗");
        }
    }
}