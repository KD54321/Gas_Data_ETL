## Natural Gas Pipeline Capacity ETL

This console application automates the extraction, transformation and loading (ETL) of natural gas pipeline capacity data from Energy Transfer's public API into a PostgreSQL database.

## Overview
The ETL pipeline downloads operationally available capacity data from Energy Transfer's public API, validates the data, and stores it in a structured relational database. 
The application automatically retrieves data from the last three days, given different cycles. This ensures a comprehensive historical tracking of pipeline capacity metrics.
### Key features
- Automated Data Retrieval: Downloads csv data from Energy Transfer's public API.
- Multi-day processing: Retrieves and processes data from the last 3 gas days.
- Data validation: Validates numeric fields.

## Architecture
```
ConsoleApp1/
├── Models/
│   └── CapacityRecord.cs        # Data model and CSV mapping
├── Services/
│   ├── CsvDownloader.cs         # HTTP client for API requests
│   └── CsvParser.cs             # CSV parsing and validation
├── sql/
│   ├── schema.sql               # Database schema definition
│   └── CapacityRepository.cs    # Data access layer
└── Program.cs                   # Application entry point
```

## TechStack
- .NET 10/C#
- CsvHelper
- Dapper
- Npgsql
- PostgreSQL

## How to run
1. Clone the repository
2. Create the database on postgreSQL using the schema.sql ddl in the sql folder
3. Configure the database connection by modifying the connection String in Program.cs
```   
var repository = new CapacityRepository(
       "Host=localhost;Username=postgres;Password=your_password;Database=gasDb"
   );
```
4. Modify the gasDays and the cycle in the main function in Program.cs to the days/cycle you want the data from:
- Cycle 0: Timely
- Cycle 1: Evening
- Cycle 3: Intraday 1
- Cycle 4: Intraday 2
- Cycle 5: Final
- Cycle 7: Intraday 3
```
var gasDay = new DateTime(2026, 1, 1);  // Target date
var cycle = 3;  
```
5. Run Program.cs
