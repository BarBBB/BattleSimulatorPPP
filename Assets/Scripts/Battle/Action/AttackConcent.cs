public class AttackConcent : PcAction
{
    public AttackConcent()
    {
        Param.Hits = 5;
        Param.Critical = 1;

        EndTunEnd = true;

        name = ActionManage.ATTACK_CONCENT;
    }
}
