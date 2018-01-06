public class Poison2 : BadStatus
{
    public Poison2()
    {
        name = "猛毒";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return pc.baseParam.MaxHP * ( 5 / 100);
    }
}
