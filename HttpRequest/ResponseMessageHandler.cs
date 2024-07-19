using Newtonsoft.Json;

namespace System.Net.Http;
public class ResponseMessageHandler
{
    public static async Task<T> Set<T>(HttpResponseMessage httpResponse)
    {
        var stringResponse = await httpResponse.Content.ReadAsStringAsync();

        try
        {
            var response = JsonConvert.DeserializeObject<T>(stringResponse);

            var type = httpResponse.GetType();
            var statusCode = type.GetProperty(nameof(HttpStatusCode));
            statusCode?.SetValue(httpResponse, httpResponse.StatusCode, null);

            return response!;
        }
        catch (Exception ex)
        {
            var message = nameof(ResponseMessageHandler) + " -> " + nameof(Set);
            throw new Exception(message, ex.InnerException);
        }
    }
}