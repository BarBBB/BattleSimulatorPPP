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


    public static void AddFullAttack(PlayerCharacter pc)
    {
        if (!pc.Action.ActionList.Contains(FULL_ATTACK)) {
            pc.Action.ActionList.Add(FULL_ATTACK);
            pc.paramCorrect.Hits += 5;
            pc.paramCorrect.Critical += 5;
            pc.paramCorrect.Avoid += -10;
            pc.paramCorrect.Fumble += 10;
        }
    }

    public static void DelFullAttack(PlayerCharacter pc)
    {
        if (pc.Action.ActionList.Contains(FULL_ATTACK))
        {
            pc.Action.ActionList.Remove(FULL_ATTACK);
            pc.paramCorrect.Hits -= 5;
            pc.paramCorrect.Critical -= 5;
            pc.paramCorrect.Avoid -= -10;
            pc.paramCorrect.Fumble -= 10;
        }
    }

    public static void AddFulDefense(PlayerCharacter pc)
    {
        if (!pc.Action.ActionList.Contains(FULL_DEFENSE))
        {
            pc.Action.ActionList.Add(FULL_DEFENSE);
            pc.paramCorrect.Defense += 20;
            pc.paramCorrect.Avoid += 10;
        }
    }

    public static void DelFullDefense(PlayerCharacter pc)
    {
        if (pc.Action.ActionList.Contains(FULL_DEFENSE))
        {
            pc.Action.ActionList.Remove(FULL_DEFENSE);
            pc.paramCorrect.Defense -= 20;
            pc.paramCorrect.Avoid -= 10;
        }
    }

    public static void AddlAttackConcent(PlayerCharacter pc)
    {
        if (!pc.Action.ActionList.Contains(ATTACK_CONCENT))
        {
            pc.Action.ActionList.Add(ATTACK_CONCENT);
            pc.paramCorrect.Hits += 5;
            pc.paramCorrect.Critical += 1;
        }
    }

    public static void DelAttackConcent(PlayerCharacter pc)
    {
        if (pc.Action.ActionList.Contains(ATTACK_CONCENT))
        {
            pc.Action.ActionList.Remove(ATTACK_CONCENT);
            pc.paramCorrect.Hits -= 5;
            pc.paramCorrect.Critical -= 1;
        }
    }

    public static void AddDefenseConcent(PlayerCharacter pc)
    {
        if (!pc.Action.ActionList.Contains(DEFENSE_CONCENT))
        {
            pc.Action.ActionList.Add(DEFENSE_CONCENT);
            pc.paramCorrect.Defense += 6;
            pc.paramCorrect.Avoid += 3;
            pc.paramCorrect.Resist += 6;
        }
    }

    public static void DelDefenseConcent(PlayerCharacter pc)
    {
        if (pc.Action.ActionList.Contains(DEFENSE_CONCENT))
        {
            pc.Action.ActionList.Remove(DEFENSE_CONCENT);
            pc.paramCorrect.Defense -= 6;
            pc.paramCorrect.Avoid -= 3;
            pc.paramCorrect.Resist -= 6;
        }
    }

    public static void DelAllAction(PlayerCharacter pc)
    {
        DelFullAttack(pc);
        DelFullDefense(pc);
        DelAttackConcent(pc);
        DelDefenseConcent(pc);
    }
}
