using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string content;
            string expr = @"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)";
            HashSet<string> set = new HashSet<string>();

            //checking for passed parameters
            if (args == null || args.Length == 0 || String.IsNullOrEmpty(args[0]))
                throw new ArgumentNullException(nameof(args), "Parameter was not passed");

            string wersiteUrl = args[0];
            using (var httpClient = new HttpClient())
            {
                //checking for valid url
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(wersiteUrl);
                    //checking for errors while downloading
                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Error while downloading the page");
                    content = await response.Content.ReadAsStringAsync();
                }
                catch
                {
                    throw new ArgumentException("URL is not valid");
                }
            }

            //collecting unique values
            MatchCollection match = Regex.Matches(content, expr);
            foreach (Match m in match)
            {
                set.Add(m.Value);
            }

            //printing the result
            if (set.Count == 0)
                Console.WriteLine("E-mail addresses not found");
            else
            {
                foreach(string st in set)
                {
                    Console.WriteLine(st);
                }
            }
        }
    }

}
