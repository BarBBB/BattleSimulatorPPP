using UnityEngine.UI;

public class PcParameter : Parameter
{
    private string title;

    private string pcName;

    private string pcClass;

    private string esprit;

    private RawImage icon;

    private Skill skill1;

    private Skill skill2;

    private Skill skill3;

    private Skill skill4;


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

    public string PcClass
    {
        get
        {
            return pcClass;
        }

        set
        {
            pcClass = value;
        }
    }

    public string Esprit
    {
        get
        {
            return esprit;
        }

        set
        {
            esprit = value;
        }
    }
}