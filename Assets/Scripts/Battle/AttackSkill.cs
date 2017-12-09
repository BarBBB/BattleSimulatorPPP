
using System;
using System.Collections.Generic;

public class AttackSkill : Skill{

    private int power = 0;

    private int hits = 0;

    private int ct = 0;

    private int fb = 0;

    private List<Effect> effectList = new List<Effect>();

    private List<BadStatus> bsList = new List<BadStatus>();

    public AttackSkill()
    {
        this.Tyep = Skill.TYPE_ATTACK;
    }

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
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

    public int Ct
    {
        get
        {
            return ct;
        }

        set
        {
            ct = value;
        }
    }

    public int Fb
    {
        get
        {
            return fb;
        }

        set
        {
            fb = value;
        }
    }

    public List<Effect> EffectList
    {
        get
        {
            return effectList;
        }

        set
        {
            effectList = value;
        }
    }

    public List<BadStatus> BsList
    {
        get
        {
            return bsList;
        }

        set
        {
            bsList = value;
        }
    }
}
