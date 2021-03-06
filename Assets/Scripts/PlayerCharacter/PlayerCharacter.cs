﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Token
{
    public PcParameter baseParam = new PcParameter();

    public RawImage icon;

    public TitleText Title;

    public NameText PcName;

    public HpText Hp;

    public ApText Ap;

    public ActionText Action;

    public BsText Bs;

    public EnchantText Enchantt;

    private Skill skill1;

    private Skill skill2;

    private Skill skill3;

    private Skill skill4;

    private int initiative;

    private int attackedCount = 0;

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

    public int AttackedCount
    {
        get
        {
            return attackedCount;
        }

        set
        {
            attackedCount = value;
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

        Hp.MaxHp = baseParam.MaxHP;
        Hp.CurrentHp = baseParam.MaxHP;
        Ap.MaxAp = baseParam.MaxAP;
        Ap.CurrentAp = baseParam.MaxAP;

        Skill1 = pc.Skill1;
        if (Skill1 != null) {
            Debug.Log("Skill1.Name:" + Skill1.getName());
        }
        Skill2 = pc.Skill2;
        Skill3 = pc.Skill3;
        Skill4 = pc.Skill4;
    }


    public int getPAttack()
    {
        return baseParam.PAttack + Action.getPAttack() + Bs.getPAttack() + Enchantt.getPAttack();
    }
    public int getMAttack()
    {
        return baseParam.MAttack + Action.getMAttack() + Bs.getMAttack() + Enchantt.getMAttack();
    }
    public int getExf()
    {
        return baseParam.Exf + Action.getExf() + Bs.getExf() + Enchantt.getExf();
    }
    public int getDefense()
    {
        return baseParam.Defense + Action.getDefense() + Bs.getDefense() + Enchantt.getDefense();
    }
    public int getResist()
    {
        return baseParam.Resist + Action.getResist() + Bs.getResist() + Enchantt.getResist();
    }
    public int getExa()
    {
        return baseParam.Exa + Action.getExa() + Bs.getExa() + Enchantt.getExa();
    }
    public int getHits()
    {
        return baseParam.Hits + Action.getHits() + Bs.getHits() + Enchantt.getHits();
    }
    public int getAvoid()
    {
        return baseParam.Avoid + Action.getAvoid() + Bs.getAvoid() + Enchantt.getAvoid();
    }
    public int getCritical()
    {
        return baseParam.Critical + Action.getCritical() + Bs.getCritical() + Enchantt.getCritical();
    }
    public int getReaction()
    {
        return baseParam.Reaction + Action.getReaction() + Bs.getReaction() + Enchantt.getReaction();
    }
    public int getMobility()
    {
        return baseParam.Mobility + Action.getMobility() + Bs.getMobility() + Enchantt.getMobility();
    }

    public int getFumble()
    {
        int fb = baseParam.Fumble + Action.getFumble() + Bs.getFumble() + Enchantt.getFumble();

        if (Bs.BsList.Find(x => x.getName().Equals("不運")) != null)
        {
            fb = fb * 2;
        }
        
        if (Bs.BsList.Find(x => x.getName().Equals("魔凶")) != null)
        {
            fb = fb * 3;
        }

        return fb;
    }
}
