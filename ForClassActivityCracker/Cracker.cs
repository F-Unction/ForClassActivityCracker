using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForClassActivityCracker
{
    class Cracker
    {
        private string url;
        private int times;
        private ChromeDriver driver;
        private Thread thread;

        public Cracker(string url, int times)
        {
            this.url = url + "&embed=true";
            this.times = times;
        }

        public void start()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            driverService.HideCommandPromptWindow = true;
            options.AddArgument("headless");
            driver = new ChromeDriver(driverService, options);

            thread = new Thread(CrackForClass);
            thread.Start();
        }

        public void stop()
        {
            if (!thread.IsAlive)
            {
                thread.Abort();
            }
            driver.Close();
            driver.Quit();
        }

        private void CrackForClass()
        {
            if (url.Length != 0)
            {
                if (times != 0)
                {
                    for (var i = 0; i < times; i++)
                    {
                        if (url.Length != 0)
                        {
                            driver.Url = url;
                        }
                    }
                    return;
                }
                else
                {
                    while (url.Length != 0)
                    {
                        driver.Url = url;
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}