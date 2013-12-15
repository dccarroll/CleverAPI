using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CleverAPI
{
	public class Program
	{
		static void Main(string[] args)
		{
			using (var client = new HttpClient(
				new HttpClientHandler {
					AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
				})
			)
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
					Encoding.ASCII.GetBytes("INNOVATE_NYC")));

				var result = JsonConvert.DeserializeObject<Result>(client.GetAsync("https://api.getclever.com/v1.1/sections?limit=1000").Result.Content.ReadAsStringAsync().Result);

				decimal studentCount = result.Data.Sum(x => x.data.Students.Count());
				decimal classCount = result.Data.Count();

				var average = studentCount / classCount;

				Console.WriteLine("Average class size: {0}", average);
				Console.WriteLine("Press the any key to continue...");
				Console.ReadKey();
			}
		}
	}
}
