public class Bloody3 : BadStatus
{
    public Bloody3()
    {
        name = "失血";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return 300;
    }
}
