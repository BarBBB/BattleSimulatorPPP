using System.Collections.Generic;

public class PcParamList
{
    public readonly static PcParamList Instance = new PcParamList();

    public List<PcParameter> pcs = new List<PcParameter>();
}