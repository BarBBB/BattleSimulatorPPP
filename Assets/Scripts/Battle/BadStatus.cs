public class BadStatus
{
    private int fading;

    public BadStatus()
    {
        fading = 3;
    }

    public int fade()
    {
        return fading--;
    }

    virtual public int bsHpDamage(PlayerCharacter pc)
    {
        return 0;
    }

    virtual public int bsApDamage(PlayerCharacter pc)
    {
        return 0;
    }

    virtual public string getName()
    {
        return "BS";
    }
}