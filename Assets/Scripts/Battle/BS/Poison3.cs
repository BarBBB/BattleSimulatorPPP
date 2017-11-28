public class Poison3 : BadStatus
{
    override public int bsHpDamage(PlayerCharacter pc)
    {
        return pc.baseParam.MaxHP * ( 10 / 100);
    }

    override public string getName()
    {
        return "致死毒";
    }
}
