public class BadStatus
{
    public const int START_COUNT = 3;

    public Parameter Param = new Parameter();

    private int count;

    protected string name = "BS";

    public BadStatus()
    {
        init();
    }

    public void init()
    {
        count = START_COUNT;
    }

    public int fade()
    {
        return --count;
    }

    public int getCount()
    {
        return count;
    }

    virtual public int bsHpDamage(PlayerCharacter pc)
    {
        return 0;
    }

    virtual public int bsApDamage(PlayerCharacter pc)
    {
        return 0;
    }

    public string getName()
    {
        return name;
    }
}