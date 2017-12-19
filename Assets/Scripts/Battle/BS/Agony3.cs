public class Agony3 : BadStatus
{
    public Agony3()
    {
        name = "懊悩";
    }

    override public int bsApDamage(PlayerCharacter pc)
    {
        return 150;
    }
}
