using UnityEngine.UI;

public class PcParameter
{
    private string title;

    private string pcName;

    private int maxHP = 0;

    private int maxAP = 0;

    private int pAttack = 0;

    private int mAttack = 0;

    private int defense = 0;

    private int resist = 0;

    private int hits = 0;

    private int avoid = 0;

    private int critical = 0;

    private int reaction = 0;

    private int mobility = 0;

    private int fumble = 0;

    private int exf = 0;

    private int exa = 0;

    private RawImage icon;

    private Skill skill1;

    private Skill skill2;

    private Skill skill3;

    private Skill skill4;


    public int MaxHP
    {
        get
        {
            return maxHP;
        }

        set
        {
            maxHP = value;
        }
    }

    public int MaxAP
    {
        get
        {
            return maxAP;
        }

        set
        {
            maxAP = value;
        }
    }

    public int PAttack
    {
        get
        {
            return pAttack;
        }

        set
        {
            pAttack = value;
        }
    }

    public int MAttack
    {
        get
        {
            return mAttack;
        }

        set
        {
            mAttack = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int Resist
    {
        get
        {
            return resist;
        }

        set
        {
            resist = value;
        }
    }

    public int Hits
    {
        get
        {
            return hits;
        }

        set
        {
            hits = value;
        }
    }

    public int Avoid
    {
        get
        {
            return avoid;
        }

        set
        {
            avoid = value;
        }
    }

    public int Critical
    {
        get
        {
            return critical;
        }

        set
        {
            critical = value;
        }
    }

    public int Reaction
    {
        get
        {
            return reaction;
        }

        set
        {
            reaction = value;
        }
    }

    public int Mobility
    {
        get
        {
            return mobility;
        }

        set
        {
            mobility = value;
        }
    }

    public int Fumble
    {
        get
        {
            return fumble;
        }

        set
        {
            fumble = value;
        }
    }

    public int Exf
    {
        get
        {
            return exf;
        }

        set
        {
            exf = value;
        }
    }

    public int Exa
    {
        get
        {
            return exa;
        }

        set
        {
            exa = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public string PcName
    {
        get
        {
            return pcName;
        }

        set
        {
            pcName = value;
        }
    }

    public RawImage Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public Skill Skill1
    {
        get
        {
            return skill1;
        }

        set
        {
            skill1 = value;
        }
    }

    public Skill Skill2
    {
        get
        {
            return skill2;
        }

        set
        {
            skill2 = value;
        }
    }

    public Skill Skill3
    {
        get
        {
            return skill3;
        }

        set
        {
            skill3 = value;
        }
    }

    public Skill Skill4
    {
        get
        {
            return skill4;
        }

        set
        {
            skill4 = value;
        }
    }
}