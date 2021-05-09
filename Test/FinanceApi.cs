
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Test.Stock;

namespace Test
{
    public static class FinanceApi
    {
        static HttpClient client = new HttpClient();

        public static async Task GetProductAsync(string path)
        {
            client.BaseAddress = new Uri("https://www.alphavantage.co");
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string s = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                //object e = s.FromCsv<List<StockData>>();
                var root = JsonDocument.Parse(s);
                var w = root.RootElement.EnumerateObject();
                var time = root.RootElement.GetProperty("Time Series (Daily)");
                var datapoints = time.EnumerateObject();

                var ei = JsonSerializer.Deserialize<StockInfoDaily>(s);
                var ekk = ei.TimeSeriesDaily.Values;
                List<decimal> CloseValues = new List<decimal>();
                foreach ( var ez in ekk)
                {
                    string close = ez.close.Replace(".", ",");
                    CloseValues.Add(decimal.Parse(close));
                }
                Console.WriteLine(s);
            }
        }

        private static string CleanJsonFromSequenceNumbers(string jsonString)
        {
            // "(\d+)(\.)?(\d+)?[a-z]?[\.\:]\s
            return Regex.Replace(jsonString, "\"(\\d+)(\\.)?(\\d+)?[a-z]?[\\.\\:]\\s", "\"", RegexOptions.Multiline);
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://www.alphavantage.com/query?");
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //// Create a new product
                //Product product = new Product
                //{
                //    Name = "Gizmo",
                //    Price = 100,
                //    Category = "Widgets"
                //};

                //var url = await CreateProductAsync(product);
                //Console.WriteLine($"Created at {url}");

                //// Get the product
                //product = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);

                //// Update the product
                //Console.WriteLine("Updating price...");
                //product.Price = 80;
                //await UpdateProductAsync(product);

                //// Get the updated product
                //product = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);

                //// Delete the product
                //var statusCode = await DeleteProductAsync(product.Id);
                //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
