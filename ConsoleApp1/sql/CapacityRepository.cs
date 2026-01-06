using System.Data.Common;
using Dapper;
using Npgsql;

public class CapacityRepository{
    private string dbConnectionString;

    public CapacityRepository(string conn)
    {
        dbConnectionString = conn;
    }

    public void InsertQueries(IEnumerable<CapacityRecord> records)
    {
        var connection = new NpgsqlConnection(dbConnectionString); //"Host=localhost;Username=postgres;Password=password;Database=gasDb";
        const string sql = @"INSERT INTO operationally_available_capacity(
            gas_day, gas_cycle, loc, loc_zn, loc_name, loc_purp_desc, loc_qti, flow_ind, dc, opc, tsq, oac, it, auth_overrun_ind, nom_cap_exceed_ind, all_qty_avail, qty_reason
            )
            VALUES(
            @GasDay, @cycle, @loc, @locZn, @locName, @locPurpDesc, @locQTI, @flowInd, @DC, @OPC, @TSQ, @OAC, @IT, @authOverrunInd, @nomCapExceedInd, @allQtyAvail, @qtyReason
            )
            ON CONFLICT (gas_day, gas_cycle, loc) DO NOTHING";
            

            connection.Execute(sql, records);
    }
}