public class Bloody2 : BadStatus
{
    public Bloody2()
    {
        name = "流血";
    }

    override public int bsHpDamage(PlayerCharacter pc)
    {
        return 200;
    }
}
