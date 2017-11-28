public class Poison1 : BadStatus
{
    override public int bsHpDamage(PlayerCharacter pc)
    {
        return 100;
    }

    override public string getName()
    {
        return "毒";
    }
}
