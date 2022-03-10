using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace cwiczenia_1_wogyfikacja
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                 string websiteUrl = args[0];
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("No url written");
                Environment.Exit(1);
            }
           
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(args[0]);
            
            
                var content =  await response.Content.ReadAsStringAsync();
                var regex = Regex.Matches(content, @"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.+]+")
                            .OfType<Match>()
                            .Select (m => m.Groups[0].Value)
                            .Distinct()
                            .ToList();

                if(regex.Capacity == 0){
                    Console.WriteLine("Nie znaleziono adresów email");
                }
                else{
                  foreach (String item in regex)
                {
                    Console.WriteLine(item);
                }  
                }

                
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("This url is incorrect or the site does not exist"); // prawde mowiac nie bylem pewny jak zrobic 
                                                                                        // oddzielne warunki do paru, więc zostawiłem nieco ogólnie
            }
            httpClient.Dispose();
        }
    }
}
