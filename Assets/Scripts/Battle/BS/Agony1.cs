public class Agony1 : BadStatus
{
    public Agony1()
    {
        name = "窒息";
    }

    override public int bsApDamage(PlayerCharacter pc)
    {
        return 50;
    }
}
