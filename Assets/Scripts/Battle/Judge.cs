using System;
using UnityEngine;

public static class Judge
{
    public const int CT_VALUE = 10000;
    public const int FB_VALUE = -10000;
    public const int STAND_BY = 10000;
    public const int CF_BOUND = 8000;

    public const int LC_BOUND = 100;
    public const int HL_BOUND = 130;
    public const int SH_BOUND = 160;

    public const int LIGHT_HIT_RATE = 50;
    public const int CLEAN_HIT_RATE = 100;
    public const int HEAVY_HIT_RATE = 150;
    public const int SMASH_HIT_RATE = 200;

    public const int MAX_DEFENSE_RATE = 70;

    private static int roll()
    {
        int dice = UnityEngine.Random.Range(1, 101);
        ManageScroll.Log("D100 = " + dice);
        return dice;
    }

    private static bool ctJudge(int target, int ct, int fb)
    {
        int dice = roll();

        if (fb >= dice)
        {
            ManageScroll.Log("ファンブル");
            return false;
        }
        else if (100 - ct <= dice)
        {
            ManageScroll.Log("クリティカル");
            return true;
        }
        else if (dice >= target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool nonCtJudge(int target)
    {

        if (roll() >= target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static int ctRoll(int target, int ct, int fb)
    {
        int dice = roll();

        if (fb >= dice)
        {
            ManageScroll.Log("ファンブル");
            return target + dice + FB_VALUE;
        }
        else if (100 - ct <= dice)
        {
            ManageScroll.Log("クリティカル");
            return target + dice + CT_VALUE;
        }
        else
        {
            return target + dice;
        }
    }


    public static int initiativeRoll(string name, int reaction)
    {
        ManageScroll.Log(name  + ">【反応判定】："　+ reaction);
        int value = reaction + roll();
        ManageScroll.Log("反応値：" + value);
        return value;
    }

    public static bool bsResistJudge(string name, int resist, int ct, int fb)
    {
        ManageScroll.Log(name + ">【特殊抵抗判定】：" + resist);
        bool result = ctJudge(100 - resist,ct ,fb);
        if (result)
        {
            ManageScroll.Log("成功");
        }
        else
        {
            ManageScroll.Log("失敗");
        }
        return result;
    }

    public static bool exaJudge(string name, int exa)
    {
        ManageScroll.Log(name + ">【EXA判定】：" + exa);
        bool result = nonCtJudge(100 - exa);
        if (result)
        {
            ManageScroll.Log("成功");
        }
        else
        {
            ManageScroll.Log("失敗");
        }
        return result;
    }

    public static bool exfJudge(string name, int exf)
    {
        ManageScroll.Log(name + ">【EXF判定】：" + exf);
        bool result = nonCtJudge(100 - exf);
        if (result)
        {
            ManageScroll.Log("成功");
        }
        else
        {
            ManageScroll.Log("失敗");
        }
        return result;
    }

    public static int hitsRoll(string name, int hits, int ct, int fb)
    {
        ManageScroll.Log(name + ">【命中判定】：" + hits);
        int value = ctRoll(hits, ct, fb);
        if (value > CF_BOUND)
        {
            ManageScroll.Log("命中値：" + (value - CT_VALUE));
        }else if (value < - CF_BOUND)
        {
            ManageScroll.Log("命中値：" + (value - FB_VALUE));
        }else
        {
            ManageScroll.Log("命中値：" + value);
        }
        return value;
    }

    public static int avoidRoll(string name, int avoid, int ct, int fb)
    {
        ManageScroll.Log(name + ">【回避判定】：" + avoid);
        int value = ctRoll(avoid, ct, fb);
        if (value > CF_BOUND)
        {
            ManageScroll.Log("回避値：" + (value - CT_VALUE));
        }
        else if (value < -CF_BOUND)
        {
            ManageScroll.Log("回避値：" + (value - FB_VALUE));
        }
        else
        {
            ManageScroll.Log("回避値：" + value);
        }
        return value;
    }

    public static int hitRateRoll(int hitCorrect)
    {
        ManageScroll.Log("【ヒットレート算出】");
        hitCorrect = hitCorrect + roll();
        ManageScroll.Log("命中度：" + hitCorrect);

        if (LC_BOUND > hitCorrect)
        {
            ManageScroll.Log("ライトヒット");
            return LIGHT_HIT_RATE;
        }
        else if (HL_BOUND > hitCorrect & hitCorrect >= LC_BOUND)
        {
            ManageScroll.Log("クリーンヒット");
            return CLEAN_HIT_RATE;
        }
        else if (SH_BOUND > hitCorrect & hitCorrect >= HL_BOUND)
        {
            ManageScroll.Log("ハードヒット");
            return HEAVY_HIT_RATE;
        }
        else if (hitCorrect > SH_BOUND)
        {
            ManageScroll.Log("スマッシュヒット");
            return SMASH_HIT_RATE;
        }
        else
        {
            return 0;
        }
    }

    public static int defenseRateRoll(string name, int defense, int ct, int fb)
    {
        ManageScroll.Log(name + ">【防御技術判定】：" + defense);
        int defenseRate = 0;
        bool result = ctJudge(100 - defense, ct, fb);

        if (result)
        {
            double hoge = defense / 10;
            defenseRate = (int)Math.Floor(hoge) * 10;

            if (defenseRate >= MAX_DEFENSE_RATE)
            {
                defenseRate = MAX_DEFENSE_RATE;
            }
        }

        return defenseRate;
    }
}
