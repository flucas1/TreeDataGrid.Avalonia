using System.Net.Http;

namespace TreeDataGridDemo.Utils;

internal class HttpClientEx : HttpClient
{
    private const string UserAgent = @"AvaloniaTreeDataGridSample/1.0 (https://avaloniaui.net; team@avaloniaui.net)";

    public HttpClientEx()
    {
        DefaultRequestHeaders.Add("User-Agent", UserAgent);
    }
}
