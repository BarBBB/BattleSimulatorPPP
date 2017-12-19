public class Poison3 : BadStatus
{
    public Poison3()
    {
        name = "致死毒";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return pc.baseParam.MaxHP * ( 10 / 100);
    }
}
