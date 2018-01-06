public class Fire2 : BadStatus
{
    public Fire2()
    {
        name = "業炎";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return pc.baseParam.MaxHP * (5 / 100);
    }
}
