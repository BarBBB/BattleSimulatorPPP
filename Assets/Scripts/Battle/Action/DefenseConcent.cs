public class DefenseConcent : PcAction
{
    public DefenseConcent()
    {
        Param.Defense = 6;
        Param.Resist = 6;
        Param.Avoid = 3;

        EndTunEnd = true;

        name = ActionManage.DEFENSE_CONCENT;
    }
}
