using System.Net.Http.Headers;
using System.Text.Json;

namespace WorksThedaily.WEB.Utils
{
    public static class HttpClientExtension
    {
        public static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: " +
                    $"{response.ReasonPhrase}");
            }
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataAsString,
                new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });
        }
    }
}
