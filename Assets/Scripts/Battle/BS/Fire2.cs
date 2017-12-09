public class Fire2 : BadStatus
{
    override public int bsHpDamage(PlayerCharacter pc)
    {
        return pc.baseParam.MaxHP * (5 / 100);
    }

    override public string getName()
    {
        return "業炎";
    }
}
