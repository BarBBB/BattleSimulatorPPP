public class Poison1 : BadStatus
{
    public Poison1()
    {
        name = "毒";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return 100;
    }
}
