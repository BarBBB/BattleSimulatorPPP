public class PcAction  {
    public Parameter Param = new Parameter();

    private bool endTunEnd = false;

    protected string name = "アクション";

    public bool EndTunEnd
    {
        get
        {
            return endTunEnd;
        }

        set
        {
            endTunEnd = value;
        }
    }

    public string getName()
    {
        return name;
    }
}
