
using System;
using System.Collections.Generic;

public class HealSkill : Skill{

    private int hp = 0;

    private int ap = 0;

    private int bs = 0;

    public HealSkill()
    {
        this.Tyep = Skill.TYPE_HEAL;
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Ap
    {
        get
        {
            return ap;
        }

        set
        {
            ap = value;
        }
    }

    public int Bs
    {
        get
        {
            return bs;
        }

        set
        {
            hp = bs;
        }
    }
}
