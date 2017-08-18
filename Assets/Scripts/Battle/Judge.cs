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


    public static int initiativeRoll(PlayerCharacter pc)
    {
        ManageScroll.Log(pc.PcName.Name+ ">【反応判定】："　+ pc.getRaction());
        int value = pc.getRaction() + roll();
        ManageScroll.Log("反応値：" + value);
        return value;
    }

    public static bool bsResistJudge(PlayerCharacter pc)
    {
        ManageScroll.Log(pc.PcName.Name + ">【特殊抵抗判定】：" + pc.getResist());
        bool result = nonCtJudge(100 - pc.getResist());
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

    public static bool exaJudge(PlayerCharacter pc)
    {
        ManageScroll.Log(pc.PcName.Name + ">【EXA判定】：" + pc.getExa());
        bool result = nonCtJudge(100 - pc.getExa());
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

    public static bool exfJudge(PlayerCharacter pc)
    {
        ManageScroll.Log(pc.PcName.Name + ">【EXF判定】：" + pc.getExf());
        bool result = nonCtJudge(100 - pc.getExf());
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

    public static int hitsRoll(PlayerCharacter pc)
    {
        ManageScroll.Log(pc.PcName.Name + ">【命中判定】：" + pc.getHits());
        int value = ctRoll(pc.getHits(), pc.getCritical(), pc.getFumble());
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

    public static int avoidRoll(PlayerCharacter pc)
    {
        ManageScroll.Log(pc.PcName.Name + ">【回避判定】：" + pc.getAvoid());
        int value = ctRoll(pc.getAvoid(), pc.getCritical(), pc.getFumble());
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
            ManageScroll.Log("ヘビーヒット");
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

    public static int defenseRateRoll(PlayerCharacter pc)
    {
        ManageScroll.Log(pc.PcName.Name + ">【防御技術判定】：" + pc.getDefense());
        int defenseRate = 0;
        int dice = roll();

        if (dice >= 100 - pc.getDefense())
        {

            double hoge = pc.getDefense() / 10;
            defenseRate = (int)Math.Floor(hoge) * 10;

            if (defenseRate >= MAX_DEFENSE_RATE)
            {
                defenseRate = MAX_DEFENSE_RATE;
            }
        }

        return defenseRate;
    }
}
