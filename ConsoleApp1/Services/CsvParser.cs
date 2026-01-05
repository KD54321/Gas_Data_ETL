using System.Globalization;
using CsvHelper;


public class CsvParser
{
    public IEnumerable<CapacityRecord> Parse(string csv, DateTime gasDay, int cycle)
    {
        var reader = new StringReader(csv);
        var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

        csvReader.Context.RegisterClassMap<CapacityRecordClassMap>();
        var records = csvReader.GetRecords<CapacityRecord>().ToList();
        var validRecords = new List<CapacityRecord>();

        foreach(var record in records)
        {
            if (record.DC < 0)
            {
                Console.WriteLine($"Invalid DC value {record.DC} for location {record.loc}");
                continue;
            }
            if (record.OPC < 0)
            {
                Console.WriteLine($"Invalid OPC value {record.OPC} for location {record.loc}");
                continue;
            }
            if (record.TSQ < 0)
            {
                Console.WriteLine($"Invalid TSQ value {record.TSQ} for location {record.loc}");
                continue;
            }
            if (record.OAC < 0)
            {
                Console.WriteLine($"Invalid OAC value {record.OAC} for location {record.loc}");
                continue;
            }
            record.GasDay = gasDay.Date;
            record.cycle = cycle;

            validRecords.Add(record);
        }
        return validRecords;
    }
}