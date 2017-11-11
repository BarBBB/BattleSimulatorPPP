﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Token
{
    public PcParameter baseParam = new PcParameter();

    public PcParameter paramCorrect = new PcParameter();

    public RawImage icon;

    public TitleText Title;

    public NameText PcName;

    public HpText Hp;

    public ApText Ap;

    public ActionText Action;

    public BsText Bs;

    public EnchantText enchantText;


    //private List<Declaration> DeclaratList;

    private Skill skill1;

    private Skill skill2;

    private Skill skill3;

    private Skill skill4;

    private int initiative;

    public int Initiative
    {
        get
        {
            return initiative;
        }

        set
        {
            initiative = value;
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


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setPcParameter(PcParameter pc)
    {
        baseParam.MaxHP = pc.MaxHP;
        baseParam.MaxAP = pc.MaxAP;
        baseParam.PAttack = pc.PAttack;
        baseParam.MAttack = pc.MAttack;
        baseParam.Exf = pc.Exf;
        baseParam.Defense = pc.Defense;
        baseParam.Resist = pc.Resist;
        baseParam.Exa = pc.Exa;
        baseParam.Hits = pc.Hits;
        baseParam.Avoid = pc.Avoid;
        baseParam.Critical = pc.Critical;
        baseParam.Reaction = pc.Reaction;
        baseParam.Mobility = pc.Mobility;
        baseParam.Fumble = pc.Fumble;

        icon.texture = pc.Icon.texture;

        Title.Title = pc.Title;
        PcName.Name = pc.PcName;

        Hp.CurrentHp = baseParam.MaxHP;
        Hp.MaxHp = baseParam.MaxHP;
        Ap.CurrentAp = baseParam.MaxAP;
        Ap.MaxAp = baseParam.MaxAP;

        Skill1 = pc.Skill1;
        if (Skill1 != null) {
            Debug.Log("Skill1.Name:" + Skill1.Name);
        }
        Skill2 = pc.Skill2;
        Skill3 = pc.Skill3;
        Skill4 = pc.Skill4;
    }


    public int getPAttack()
    {
        return baseParam.PAttack + paramCorrect.PAttack;
    }
    public int getMAttack()
    {
        return baseParam.MAttack + paramCorrect.MAttack;
    }
    public int getExf()
    {
        return baseParam.Exf + paramCorrect.Exf;
    }
    public int getDefense()
    {
        return baseParam.Defense + paramCorrect.Defense;
    }
    public int getResist()
    {
        return baseParam.Resist + paramCorrect.Resist;
    }
    public int getExa()
    {
        return baseParam.Exa + paramCorrect.Exa;
    }
    public int getHits()
    {
        return baseParam.Hits + paramCorrect.Hits;
    }
    public int getAvoid()
    {
        return baseParam.Avoid + paramCorrect.Avoid;
    }
    public int getCritical()
    {
        return baseParam.Critical + paramCorrect.Critical;
    }
    public int getRaction()
    {
        return baseParam.Reaction + paramCorrect.Reaction;
    }
    public int getMobility()
    {
        return baseParam.Mobility + paramCorrect.Mobility;
    }

    public int getFumble()
    {
        return baseParam.Fumble + paramCorrect.Fumble;
    }
}
