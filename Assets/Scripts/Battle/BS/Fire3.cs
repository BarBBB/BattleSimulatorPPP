public class Fire3 : BadStatus
{
    public Fire3()
    {
        name = "炎獄";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return pc.baseParam.MaxHP * (10 / 100);
    }
}
