namespace System.Net.Http;
public class Request
{
    public Request(HttpMethod method, string url)
    {
        Method = method;
        Url = url;
    }

    public void SetParam(object param) => Param = param;
    public void SetToken(string token) => Token = token;

    public HttpMethod Method { get; set; }
    public string Url { get; }
    public object? Param { get; private set; }
    public string? Token { get; private set; }
}
