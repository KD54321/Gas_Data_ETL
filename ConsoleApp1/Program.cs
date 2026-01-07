
class Program {
    // Main Method
    public static async Task Main(String[] args){
        //modify gasDay and cycle
        var gasDay = new DateTime(2024, 1, 18);
        var cycle = 3;//0, 1, 3, 4, 5, 7 
        //past three days
        var gasDays = new List<DateTime>
        {
            gasDay,
            gasDay.AddDays(-1),
            gasDay.AddDays(-2),
        };
        
        var httpClient = new HttpClient();
        var downloader = new CsvDownloader(httpClient);
        var parser = new CsvParser();
        var repository = new CapacityRepository("Host=localhost;Username=postgres;Password=password;Database=gasDb");

        try
        {
            foreach(var gasday in gasDays)
            {
                var csvContent = await downloader.DownloadAsync(gasday, cycle);
                var records = parser.Parse(csvContent, gasday, cycle);
                repository.InsertQueries(records);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
         Console.WriteLine("done");
    }
}