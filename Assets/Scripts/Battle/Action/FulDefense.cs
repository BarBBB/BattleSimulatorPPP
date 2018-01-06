public class FulDefense : PcAction
{
    public FulDefense()
    {
        Param.Avoid = 10;
        Param.Defense = 20;

        EndTunEnd = true;

        name = ActionManage.FULL_DEFENSE;
    }
}
