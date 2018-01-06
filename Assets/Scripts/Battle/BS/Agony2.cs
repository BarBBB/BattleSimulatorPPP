public class Agony2 : BadStatus
{
    public Agony2()
    {
        name = "苦鳴";
    }

    override public int bsApDamage(PlayerCharacter pc)
    {
        return 100;
    }
}
