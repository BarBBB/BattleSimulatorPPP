using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEngine : MonoBehaviour
{
    public List<PlayerCharacter> PcList = new List<PlayerCharacter>();

    private List<PlayerCharacter> livePcList;

    public GameObject majorActionPanel;

    public GameObject minorActionPanel;

    public GameObject waitPanel;

    public GameObject winnerPanel;

    public GameObject skillPanel;

    public PlayerCharacter pcWin1;

    public PlayerCharacter pcWin2;

    public WinnerText winner;

    private bool flg;

    private string buttonCommand;

    private bool isRun()
    {
        return flg;
    }

    private Skill majorSkil;

    private bool waitFlg = false;

    private bool fullAttackFlg = false;

    // Use this for initialization
    void Start()
    {

        if (PcParamList.Instance.pcs.Count >= 2)
        {
            pcWin1.setPcParameter(PcParamList.Instance.pcs[0]);
            pcWin2.setPcParameter(PcParamList.Instance.pcs[1]);

            PcList.Add(pcWin1.GetComponent<PlayerCharacter>());
            PcList.Add(pcWin2.GetComponent<PlayerCharacter>());
        }
        else if (PcParamList.Instance.pcs.Count == 1)
        {
            pcWin1.setPcParameter(PcParamList.Instance.pcs[0]);
            PcList.Add(pcWin1.GetComponent<PlayerCharacter>());
        }

        livePcList = PcList;

        majorActionPanel.SetActive(false);
        minorActionPanel.SetActive(false);
        waitPanel.SetActive(false);
        winnerPanel.SetActive(false);
        skillPanel.SetActive(false);

        flg = true;
        StartCoroutine(battleSequence());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        // 生存PCリストが1人きりになった
        if (livePcList.Count == 1)
        {
            Debug.Log("livePcList[0].PcName.Name : " + livePcList[0].PcName.Name);
            winner.Winner = livePcList[0].PcName.Name;
            winnerPanel.SetActive(true);
            livePcList.Remove(livePcList[0]);
        }
    }

    public void buttonClickAction(string button)
    {
        buttonClickAction(button, null);
    }

    public void buttonClickAction(string button, Skill skill)
    {
        buttonCommand = button;
        Debug.Log("ButtonCommand : " + buttonCommand);
        minorActionPanel.SetActive(false);
        majorActionPanel.SetActive(false);
        waitPanel.SetActive(false);
        skillPanel.SetActive(false);
        flg = true;
        majorSkil = skill;
    }

    public void flipFullAttackFlg()
    {
        if (fullAttackFlg)
        {
            fullAttackFlg = false;
        }
        else
        {
            fullAttackFlg = true;
        }
    }

    private IEnumerator battleSequence()
    {
        int turn = 0;
        // 生存PCリストが2人以上
        while (livePcList.Count >= 2)
        {
            turn++;
            ManageScroll.Log("【第" + turn + "ターン開始】");
            yield return new WaitForSeconds(0.5f);
            while (!Input.anyKeyDown) { yield return 0; }　//キー入力待ち

            //セットアッププロセスでイニチアチブ決定
            List<PlayerCharacter> initiativeList = setUpProcess();

            //全員行動するまでループ
            while (initiativeList.Count > 0)
            {
                // 生存PCリストが2人以上
                if (livePcList.Count >= 2)
                {
                    //イニチアチブプロセス
                    yield return initiativeProcess(initiativeList);
                }else
                {
                    break;
                }
            }

            CleanUpProcess();
        }
        yield return null;
    }

    //セットアッププロセス
    private List<PlayerCharacter> setUpProcess()
    {
        //未行動PCリスト
        ManageScroll.Log("【反応判定】");
        List<PlayerCharacter> initiativeList = new List<PlayerCharacter>();

        //全てのPCに対して
        foreach (PlayerCharacter pc in PcList)
        {
            //反応判定
            pc.Initiative = Judge.initiativeRoll(pc.PcName.Name, pc.getRaction());
            //未行動PCリストに追加
            initiativeList.Add(pc);
        }

        //未行動PCリストを返す
        return initiativeList;
    }

    //イニシアチブプロセス
    private IEnumerator initiativeProcess(List<PlayerCharacter> initiativeList)
    {
        //反応値の降順にソート
        initiativeList.Sort((a, b) => b.Initiative - a.Initiative);

        //先頭のPCを取得
        PlayerCharacter turnPC = initiativeList[0];

        //取得したPCのHPが0以下の場合、イニシアチブリストから削除
        if (turnPC.Hp.CurrentHp <= 0)
        {
            initiativeList.Remove(turnPC);
            yield break;
        }

        if (turnPC.Initiative > -Judge.CF_BOUND)
        {
            ManageScroll.Log(turnPC.PcName.Name + ">【メインプロセス】反応値：" + turnPC.Initiative);
        }
        else
        {
            ManageScroll.Log(turnPC.PcName.Name + ">【メインプロセス：待機】反応値：" + (0 + turnPC.Initiative + Judge.STAND_BY));
        }

        //待機宣言
        yield return waitAction(turnPC);

        //待機の場合
        if (waitFlg)
        {
            //反応値を待機値分下げる
            turnPC.Initiative = 0 + turnPC.Initiative - Judge.STAND_BY;
            ManageScroll.Log(turnPC.PcName.Name + ">【待機宣言】");
            yield return new WaitForSeconds(0.5f);
            while (!Input.anyKeyDown) { yield return 0; }　//キー入力待ち
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            while (!Input.anyKeyDown){ yield return 0; }　//キー入力待ち

            //待機ではない場合、メインプロセス
            yield return mainProcess(turnPC);
            //メインプロセス後、未行動PCリストから削除
            initiativeList.RemoveAt(0);
        }
    }

    //待機判定
    private IEnumerator waitAction(PlayerCharacter pc)
    {
        waitFlg = false;

        if (pc.Initiative > -Judge.CF_BOUND)
        {
            // IEnumeratorを取得する
            yield return activeWaitPanel(pc);

            switch (buttonCommand)
            {
                case ActionManage.NO_WAIT:
                    break;
                case ActionManage.WAIT:
                    waitFlg = true;
                    break;
            }
        }
    }

    //メインプロセス
    private IEnumerator mainProcess(PlayerCharacter pc)
    {
        //BS効果判定
        judgeBsEffect(pc);
        ManageScroll.Log(pc.PcName.Name + ">【BS効果判定】");
        //BS自然回復判定
        judgeBsRecover(pc);
        ManageScroll.Log(pc.PcName.Name + ">【BS自然回復判定】");

        //EXA判定
        ManageScroll.Log(pc.PcName.Name + ">【EXA判定】");
        int mainActionCount = 1;
        while (Judge.exaJudge(pc.PcName.Name, pc.getExa()))
        {
            mainActionCount++;
        }
        ManageScroll.Log(pc.PcName.Name + ">【主行動回数】：" + mainActionCount + "回");
        yield return new WaitForSeconds(0.5f);
        while (!Input.anyKeyDown) { yield return 0; }　//キー入力待ち

        //能動行動選択
        ManageScroll.Log(pc.PcName.Name + ">【副行動】");
        yield return minorAction(pc);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < mainActionCount; i++)
        {
            // 生存PCリストが2人以上
            if (livePcList.Count >= 2) {
                ManageScroll.Log(pc.PcName.Name + ">【主行動】：" + (i + 1) + "回目");
                yield return majorAction(pc);
                yield return new WaitForSeconds(0.5f);
                while (!Input.anyKeyDown) { yield return 0; }　//キー入力待ち
            }
        }
    }

    //BS効果判定
    private void judgeBsEffect(PlayerCharacter pc)
    {
        //foreach (BadStatus bs in pc.Bs.BsList)
        //{
        //}
    }

    //BS自然回復判定
    private void judgeBsRecover(PlayerCharacter pc)
    {
        //List<string> tempList = new List<string>();
        //foreach (string bs in pc.Bs.BsList)
        //{
        //    if (bs.fade() > 0)
        //    {
        //        tempList.Add(bs);
        //    }
        //}
        //pc.Bs.BsList = tempList;
    }

    //副行動
    private IEnumerator minorAction(PlayerCharacter pc)
    {
        // IEnumeratorを取得する
        yield return activeMinorActionPanel(pc);

        switch (buttonCommand)
        {
            case ActionManage.MOVE:
                break;
            case ActionManage.ATTACK_CONCENT:
                ActionManage.AddlAttackConcent(pc);
                break;
            case ActionManage.DEFENSE_CONCENT:
                ActionManage.AddDefenseConcent(pc);
                break;
            case ActionManage.MARK:
                break;
            case ActionManage.MINIOR_SKILL:
                break;
            case ActionManage.BASE_ACTION:
                break;
        }
    }

    //主行動
    private IEnumerator majorAction(PlayerCharacter attacker)
    {
        fullAttackFlg = false;

        // IEnumeratorを取得する
        yield return activeMajorActionPanel(attacker);

        switch (buttonCommand)
        {
            case ActionManage.NOMAL_ATTACK:
                attackPhase(attacker);
                break;
            case ActionManage.SKILL_ATTACK:
                attackPhase(attacker);
                break;
            case ActionManage.FULL_DEFENSE:
                ActionManage.AddFulDefense(attacker);
                break;
            case ActionManage.FULL_MOVEE:
                fullMove(attacker);
                break;
            case ActionManage.BLOCK:
                block(attacker);
                break;
            case ActionManage.COVER_UP:
                coverUp(attacker);
                break;
        }
    }

    private void attackPhase(PlayerCharacter attacker)
    {
        //攻撃対象＝自分ではないPC取得
        PlayerCharacter defender = targetDecide(attacker);

        if (defender != null)
        {
            if (fullAttackFlg)
            {
                ActionManage.AddFullAttack(attacker);
            }
            ManageScroll.Log(attacker.PcName.Name + ">【攻撃対象】：" + defender.PcName.Name);
            attackRoll(attacker, defender);
        }
    }

    private void fullMove(PlayerCharacter attacker)
    {
    }

    private void block(PlayerCharacter attacker)
    {
    }

    private void coverUp(PlayerCharacter attacker)
    {
    }

    private PlayerCharacter targetDecide(PlayerCharacter attacker)
    {
        PlayerCharacter defender = null;

        foreach (PlayerCharacter target in livePcList)
        {
            if (!attacker.Equals(target))
            {
                Debug.Log("targetDecide");
                defender = target;
                break;
            }
        }
        return defender;
    }

    //攻防判定
    private void attackRoll(PlayerCharacter attacker, PlayerCharacter defender)
    {
        //判定値スキル反映
        string attackName = "";
        int atHit;
        int atCT;
        int atFB;
        int attack;
        //通常攻撃
        if (majorSkil == null)
        {
            attackName = "通常攻撃";
            atHit = attacker.getHits();
            atCT = attacker.getCritical();
            atFB = attacker.getFumble();

            //物理攻撃力と神秘攻撃力の高い方を設定
            attack = attacker.getPAttack();
            if (attack < attacker.getMAttack())
            {
                attack = attacker.getMAttack();
            }
        }
        //スキル攻撃
        else
        {
            attackName = majorSkil.Name;
            atHit = attacker.getHits() + majorSkil.Hits;
            atCT = attacker.getCritical() + majorSkil.Ct;
            atFB = attacker.getFumble() + majorSkil.Fb;
            attacker.Ap.CurrentAp = attacker.Ap.CurrentAp - majorSkil.UseAp;

            if (majorSkil.isPhysical)
            {
                attack = attacker.getPAttack() + majorSkil.Power;
            }
            else
            {
                attack = attacker.getMAttack() + majorSkil.Power;
            }
        }

        //攻防判定
        ManageScroll.Log(attacker.PcName.Name + "が" + defender.PcName.Name + "に[" + attackName + "]で攻撃した。");

        //命中判定
        int hit = Judge.hitsRoll(attacker.PcName.Name, atHit, atCT, atFB);
        //FBの場合、攻撃終了
        if (hit < -Judge.CF_BOUND)
        {
            ManageScroll.Log(attacker.PcName.Name + "の攻撃はファンブルで失敗しました。");
            return;
        }

        //回避判定
        int avoid = Judge.avoidRoll(defender.PcName.Name, defender.getAvoid(), defender.getCritical(), defender.getFumble());
        //CTの場合、攻撃終了
        if (avoid > Judge.CF_BOUND)
        {
            ManageScroll.Log(defender.PcName.Name + "はクリティカルで攻撃を回避しました。");
            return;
        }

        //命中 <= 回避の場合、攻撃終了
        if (hit <= avoid)
        {
            ManageScroll.Log(attacker.PcName.Name + "の攻撃は回避されました。");
            return;
        }
        ManageScroll.Log(attacker.PcName.Name + "の攻撃の攻撃が命中しました。");

        //命中CTの場合、CT値分命中値を下げる
        if (hit > Judge.CF_BOUND)
        {
            hit -= Judge.CT_VALUE;
        }

        //回避FBの場合、CT値分回避値を上げ回避ファンブルフラグを立てる
        bool avoidFBflg = false;
        if (avoid < -Judge.CF_BOUND)
        {
            avoid += Judge.CT_VALUE;
            avoidFBflg = true;
        }

        //命中度補正値
        int hitCorrect = hit - avoid;
        //ヒットレート算出
        int hitRate = Judge.hitRateRoll(hitCorrect);

        //クリーンヒット以上の場合、BS付与判定
        addBadStatusJudge(defender);

        //ダメージ算出
        int damege = attack * hitRate / 100;
        //ManageScroll.Log("hoge:" + damege);

        //回避FBではない場合、防御技術判定
        if (!avoidFBflg)
        {
            ManageScroll.Log(defender.PcName.Name + "は防御を試みた。");
            //防御技術判定で防御レート算出
            int defeseRate = Judge.defenseRateRoll(defender.PcName.Name, defender.getDefense());
            //防御レートだけダメージを軽減
            //ManageScroll.Log("foo:" + damege);
            damege -=  damege * defeseRate / 100;
            //ManageScroll.Log("bar:" + damege);

            if (defeseRate > 0)
            {
                ManageScroll.Log(defender.PcName.Name + "は" + defeseRate + "%のダメージを軽減した。");
            }
        }

        //ダメージ処理
        ManageScroll.Log(defender.PcName.Name + "に" + damege + "のダメージ。");
        damegeProcess(defender, damege);
    }

    //BS付与判定
    private void addBadStatusJudge(PlayerCharacter pc)
    {
    }

    //ダメージ処理
    private void damegeProcess(PlayerCharacter pc, int damege)
    {
        //ダメージ適用
        pc.Hp.CurrentHp -= damege;

        //HPが0以下の場合
        if (pc.Hp.CurrentHp <= 0)
        {
            //EXF判定に成功するとHPが1に
            if (Judge.exfJudge(pc.PcName.Name, pc.getExf()))
            {
                pc.Hp.CurrentHp = 1;
                ManageScroll.Log(pc.PcName.Name + "は歯を食いしばって立ち上がった。");
            }
            //戦闘不能になった場合、
            else
            {
                //生存PCリストから削除
                livePcList.Remove(pc);
                ManageScroll.Log(pc.PcName.Name + "は戦闘不能になった。");
            }
        }
    }

    private IEnumerator activeWaitPanel(PlayerCharacter pc)
    {
        waitPanel.SetActive(true);
        WaitPanel waitPanelScript = waitPanel.GetComponent<WaitPanel>();
        waitPanelScript.init(pc);

        flg = false;
        Func<bool> delegateMethod = isRun;
        yield return new WaitUntil(delegateMethod);
    }

    private IEnumerator activeMinorActionPanel(PlayerCharacter pc)
    {
        minorActionPanel.SetActive(true);
        MinorActionPanel minorActionPanelScript = minorActionPanel.GetComponent<MinorActionPanel>();
        minorActionPanelScript.init(pc);

        flg = false;
        Func<bool> delegateMethod = isRun;
        yield return new WaitUntil(delegateMethod);
    }

    private IEnumerator activeMajorActionPanel(PlayerCharacter pc)
    {
        majorActionPanel.SetActive(true);
        MajerActionPanel majorActionPanelScript = majorActionPanel.GetComponent<MajerActionPanel>();
        majorActionPanelScript.init(pc);

        flg = false;
        Func<bool> delegateMethod = isRun;
        yield return new WaitUntil(delegateMethod);
    }

    //クリーンアッププロセス
    private void CleanUpProcess()
    {
        //全てのPCに対して
        foreach (PlayerCharacter pc in PcList)
        {
            //全アクション解除
            ActionManage.DelAllAction(pc);
        }
    }
}
