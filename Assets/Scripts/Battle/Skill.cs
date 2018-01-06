
using System;
using System.Collections.Generic;

public class Skill {

    private string name;

    private string etc;

    private string basic;

    private int useAp;

    private string tyep;

    private bool isMiner = false;

    public const string TYPE_ATTACK = "攻撃";

    public const string TYPE_HEAL = "回復";

    public const string TYPE_ENCHANT = "付与";

    public string getName()
    {
        return name;
    }
    public void setName(string value)
    {
        name = value;
    }

    public string Etc
    {
        get
        {
            return etc;
        }

        set
        {
            etc = value;
        }
    }

    public int UseAp
    {
        get
        {
            return useAp;
        }

        set
        {
            useAp = value;
        }
    }

    public string Basic
    {
        get
        {
            return basic;
        }

        set
        {
            basic = value;
        }
    }

    public string Tyep
    {
        get
        {
            return tyep;
        }

        set
        {
            tyep = value;
        }
    }

    public bool IsMiner
    {
        get
        {
            return isMiner;
        }

        set
        {
            isMiner = value;
        }
    }
}
