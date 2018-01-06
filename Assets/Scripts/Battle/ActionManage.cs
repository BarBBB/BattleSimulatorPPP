using System;
using System.Collections.Generic;

public static class ActionManage {

    public const string NOMAL_ATTACK = "通常攻撃";

    public const string SKILL_ATTACK = "スキル";

    public const string FULL_ATTACK = "全力攻撃";

    public const string FULL_DEFENSE = "全力防御";

    public const string FULL_MOVEE = "全力移動";

    public const string BLOCK = "ブロック";

    public const string COVER_UP = "かばう";

    public const string MOVE = "移動";

    public const string ATTACK_CONCENT = "攻撃集中";

    public const string DEFENSE_CONCENT = "防御集中";

    public const string MARK = "マーク";

    public const string MINIOR_SKILL = "副属性スキル使用";

    public const string BASE_ACTION = "基本行動";

    public const string NO_WAIT = "待機しない";

    public const string WAIT = "待機する";


    public static void AddAttackConcent(PlayerCharacter pc)
    {
        pc.Action.ActionList.Add(new AttackConcent());
    }

    public static void AddDefenseConcent(PlayerCharacter pc)
    {
        pc.Action.ActionList.Add(new DefenseConcent());
    }

    public static void AddFullAttack(PlayerCharacter pc)
    {
        pc.Action.ActionList.Add(new FullAttack());
    }

    public static void AddFulDefense(PlayerCharacter pc)
    {
        pc.Action.ActionList.Add(new FulDefense());
    }

    public static void DelAllAction(PlayerCharacter pc)
    {
        pc.Action.ActionList = new List<PcAction>();
    }

    public static void DelTurnAction(PlayerCharacter pc)
    {
        List<PcAction> next = new List<PcAction>();

        foreach (PcAction action in pc.Action.ActionList)
        {
            if (!action.EndTunEnd)
            {
                next.Add(action);
            }
        }

        pc.Action.ActionList = next;

    }
}
