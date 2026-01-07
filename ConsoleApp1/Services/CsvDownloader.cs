using System.Web;
using System.Globalization;

public class CsvDownloader
{
    private HttpClient _httpClient;
    public CsvDownloader(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<string?> DownloadAsync(DateTime gasDay, int cycle)
    {
        var url = buildUrl(gasDay, cycle);
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadAsStringAsync();
    }

    private string buildUrl(DateTime gasDay, int cycle)
    {
        //https://twtransfer.energytransfer.com/ipost/capacity/operationally-available?asset=TW&gasDay=01%2F18%2F2024&f=csv&extension=csv&cycle=-1&searchType=NOM&searchString=&locType=ALL&locZone=ALL
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["f"] = "csv";
        query["extension"]="csv";
        query["asset"] = "TW";
        query["searchType"] = "NOM";
        query["searchString"] = "";
        query["locType"]= "ALL";
        query["locZone"] = "ALL";
        query["gasDay"]= gasDay.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        query["cycle"] = cycle.ToString();


        return $"https://twtransfer.energytransfer.com/ipost/capacity/operationally-available?{query}";
    }
}