public class FullAttack : PcAction
{
    public FullAttack()
    {
        Param.Hits = 5;
        Param.Critical = 5;
        Param.Avoid = -10;
        Param.Fumble = 10;

        EndTunEnd = true;

        name = ActionManage.FULL_ATTACK;
    }
}
