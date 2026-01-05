using CsvHelper.Configuration;

public class CapacityRecord
{
    public DateTime GasDay{get;set;}
    public int cycle {get;set;}
    public string loc {get;set;}
    public string locZn {get;set;}
    public string locName {get;set;}
    public string locPurpDesc {get;set;}
    public string locQTI {get;set;}
    public string flowInd {get;set;}
    public decimal? DC {get;set;}
    public decimal? OPC {get;set;}
    public decimal? TSQ {get;set;}
    public decimal? OAC {get;set;}
    public string IT {get;set;}
    public string authOverrunInd {get;set;}
    public string nomCapExceedInd {get;set;}
    public string allQtyAvail {get;set;}
    public string qtyReason {get;set;}

}

public class CapacityRecordClassMap : ClassMap<CapacityRecord>
{
    public CapacityRecordClassMap()
    {
        Map(m=>m.loc).Name("Loc");
        Map(m=>m.locZn).Name("Loc Zn");
        Map(m=>m.locName).Name("Loc Name");
        Map(m=>m.locPurpDesc).Name("Loc Purp Desc");
        Map(m=>m.locQTI).Name("Loc/QTI");
        Map(m=>m.flowInd).Name("Flow Ind");
        Map(m=>m.DC).Name("DC");
        Map(m=>m.OPC).Name("OPC");
        Map(m=>m.TSQ).Name("TSQ");
        Map(m=>m.OAC).Name("OAC");
        Map(m=>m.IT).Name("IT");
        Map(m=>m.authOverrunInd).Name("Auth Overrun Ind");
        Map(m=>m.nomCapExceedInd).Name("Nom Cap Exceed Ind");
        Map(m=>m.allQtyAvail).Name("All Qty Avail");
        Map(m=>m.qtyReason).Name("Qty Reason");

    }
}
