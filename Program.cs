using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace cwiczenia_1_wogyfikacja
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string websiteUrl = args[0];
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(websiteUrl);
            var content =  await response.Content.ReadAsStringAsync();
            var regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.+]+");
            var matches = regex.Matches(content);
            
            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
