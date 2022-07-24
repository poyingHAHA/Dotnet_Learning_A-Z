using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LoggingDemo1
{
    public class Test1
    {
        private readonly ILogger<Test1> logger;

        public Test1(ILogger<Test1> logger)
        {
            this.logger = logger;
        }

        public void Test()
        {
            logger.LogDebug("開始執行數據庫同步");
            logger.LogDebug("連接數據庫成功");
            logger.LogWarning("查找數據失敗ㄝ, 重試...");
            try
            {
                File.ReadAllText("A:/1.txt");
                logger.LogDebug("讀取成功");

            }
            catch(Exception e)
            {
                logger.LogError(e, "讀取失敗");
            }
        }
    }
}