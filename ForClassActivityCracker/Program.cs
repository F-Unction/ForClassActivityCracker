using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForClassActivityCracker
{
    static class MainClass
    {
        private static string _url;
        private static int _times;
        private static IWebDriver _driver;
        private static Thread _thread ;
        public static void Main(string[] args)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            driverService.HideCommandPromptWindow = true;
            options.AddArgument("headless");
            _driver = new ChromeDriver(driverService, options);

            Console.WriteLine("Welcome to ForClassActivityCracker. A software for getting more scores in ForClass activity.");
            Console.WriteLine("To exit, press Ctrl-C. To use, just follow the words.");
            Console.WriteLine("Copyright (C) 2020 ForClassActivityCracker by F_Unction. All rights reserved.");
        LStart:
            _thread = new Thread(CrackForClass);
            _url = ""; 
            _times = 0;
            Console.Write("input the url of your works. >");
            _url = Console.ReadLine() + "&embed=true";
            Console.Write("input scores(20 for 1) you want to get, if you inputted \"0\", we will work until you stop us. >");
            _times = int.Parse(Console.ReadLine() ?? "");
            Console.Write("Started. Press any keys to stop. >");
            _thread.Start();
            Console.ReadKey();
            if (!_thread.IsAlive)
            {
                _thread.Abort();
            }
            goto LStart;
        }

        private static void CrackForClass()
        {
            if (_url.Length != 0)
            {
                if (_times != 0)
                {
                    for (var i = 0; i < _times; i++)
                    {
                        if (_url.Length != 0)
                        {
                            _driver.Url = _url;
                        }
                    }
                    Console.WriteLine("Finished. Press any keys to back.");
                }
                else
                {
                    while (_url.Length != 0)
                    {
                        _driver.Url = _url;
                    }
                }
            }
            else
            {
                Console.WriteLine("Finished. But we don't know where is your works.");
            }
        }
    }
}
