using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ConsoleReturnJson
{
    internal static class Program
    {
        const string urlGet = "https://api.sampleapis.com/codingresources/codingResources";

        async static Task Main(string[] args)
        {
            var dataJson = await GetJsonResult();

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
            };

            var result = JsonNode.Parse(dataJson);
            if(result == null)
            {
                Console.WriteLine("Error processing data from json results");
                return;
            }

            Console.WriteLine(result.ToJsonString(jsonOptions));
        }

        async static Task<string> GetJsonResult()
        {
            string jsonReturn = "";
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, urlGet);

                request.Headers.Add("Accept", "application/json");

                var response = await client.SendAsync(request);

                if(response == null)
                {
                    return "Some Network error has occurred";
                }

                if ((response.StatusCode == HttpStatusCode.OK) || 
                    (response.StatusCode == HttpStatusCode.Created))
                {
                    jsonReturn = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Some error has occurred. Response StatusCode was: {response.StatusCode}";
                }
            }

            return jsonReturn;
        }
    }
}