using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForClassActivityCracker
{
    static class MainClass
    {
        private static List<String> _urls = new List<string>();
        private static List<Cracker> crackers = new List<Cracker>();

        public static void Main(string[] args)
        {
            var input =  Console.ReadLine();
            while (input != "")
            {
                _urls.Add(input);
                input = Console.ReadLine();
            }
            foreach (var url in _urls)
            {
                crackers.Add(new Cracker(url, 0));
                crackers[crackers.Count - 1].start();
            }
            Console.WriteLine("Started")
            Console.ReadKey();
            foreach (var tmp in crackers)
            {
                tmp.stop();
            }
        }
    }
}
