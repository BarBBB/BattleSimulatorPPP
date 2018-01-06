public class Bloody1 : BadStatus
{
    public Bloody1()
    {
        name = "出血";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return 100;
    }
}
