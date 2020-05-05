using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForClassActivityCracker
{
    class MainClass
    {
        private static string Url;
        private static int times;
        private static IWebDriver Driver;
        private static Thread thread ;
        public static void Main(string[] args)
        {
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            driverService.HideCommandPromptWindow = true;
            options.AddArgument("headless");
            Driver = new ChromeDriver(driverService, options);

            Console.WriteLine("Welcome to ForClassActivityCracker. A software for getting more scores in ForClass activity.");
            Console.WriteLine("To exit, press Ctrl-C. To use, just follow the words.");
            Console.WriteLine("Copyright (C) 2020 ForClassActivityCracker by F_Unction. All rights reserved.");
        LStart:
            thread = new Thread(CrackForClass);
            Url = ""; 
            times = 0;
            Console.Write("input the url of your works. >");
            Url = Console.ReadLine() + "&embed=true";
            Console.Write("input scores(20 for 1) you want to get, if you inputted \"0\", we will work until you stop us. >");
            times = int.Parse(Console.ReadLine());
            Console.Write("Started. Press any keys to stop. >");
            thread.Start();
            Console.ReadKey();
            if (!thread.IsAlive)
            {
                thread.Abort();
            }
            goto LStart;
        }

        private static void CrackForClass()
        {
            if (Url.Length != 0)
            {
                if (times != 0)
                {
                    for (int i = 0; i < times; i++)
                    {
                        if (Url.Length != 0)
                        {
                            Driver.Url = Url;
                        }
                    }
                    Console.WriteLine("Finished. Press any keys to back.");
                }
                else
                {
                    while (Url.Length != 0)
                    {
                        Driver.Url = Url;
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
