
using System;
using System.Collections.Generic;

public class EnchantSkill : Skill{

    public const int END_TURN_COUNT = 8;

    public Parameter Param = new Parameter();

    private bool isOther;

    public bool isMiner;

    private int count;


    public EnchantSkill(bool other)
    {
        this.Tyep = Skill.TYPE_ENCHANT;
        IsOther = other;

        init();
    }

    public void init()
    {
        count = END_TURN_COUNT;
    }

    public int fade()
    {
        return --count;
    }

    public int getCount()
    {
        return count;
    }

    public bool IsOther
    {
        get
        {
            return isOther;
        }

        set
        {
            isOther = value;
        }
    }
}
