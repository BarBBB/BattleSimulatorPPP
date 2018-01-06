public class Fire1 : BadStatus
{
    public Fire1()
    {
        name = "火炎";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return 100;
    }
}
