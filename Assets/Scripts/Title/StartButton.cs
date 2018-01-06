using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    private GameObject requirePanel;

    private PcInputWindow pcWin1;
    private PcInputWindow pcWin2;

    // Use this for initialization
    void Start () {
        Debug.Log(this);
        pcWin1 = GameObject.Find("PcInputWindow1").GetComponent<PcInputWindow>();
        pcWin2 = GameObject.Find("PcInputWindow2").GetComponent<PcInputWindow>();

        requirePanel = GameObject.Find("RequirePanel");
        requirePanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Debug.Log("[START] botton Clicked");
        if (addPlayerCharacter(pcWin1) & addPlayerCharacter(pcWin2))
        {
            Debug.Log("Move Battle Scene");
            // メインゲーム開始
            SceneManager.LoadScene("Battle");
        }
        else
        {
            Debug.Log("All status is required");
            StartCoroutine(requireMessage());
        }
    }

    private IEnumerator requireMessage()
    {
        requirePanel.SetActive(true);

        yield return new WaitForSeconds(1f);

        requirePanel.SetActive(false);
    }

    private bool addPlayerCharacter(PcInputWindow pcWin)
    {
        //if (pcWin.Title.getInputField() == "")
        //{
        //    pcWin.Title.setActivateInputField();
        //    return false;
        //}
        if (pcWin.getPcName() == "")
        {
            pcWin.getPcName();
            return false;
        }
        if (pcWin.getMaxHP() == "")
        {
            pcWin.getMaxHP();
            return false;
        }
        if (pcWin.getMaxAP() == "")
        {
            pcWin.getMaxAP();
            return false;
        }
        if (pcWin.getPAttack() == "")
        {
            pcWin.getPAttack();
            return false;
        }
        if (pcWin.getMAttack() == "")
        {
            pcWin.getMAttack();
            return false;
        }
        if (pcWin.getDefense() == "")
        {
            pcWin.getDefense();
            return false;
        }
        if (pcWin.getResist() == "")
        {
            pcWin.getResist();
            return false;
        }
        if (pcWin.getHits() == "")
        {
            pcWin.getHits();
            return false;
        }
        if (pcWin.getAvoid() == "")
        {
            pcWin.getAvoid();
            return false;
        }
        if (pcWin.getCritical() == "")
        {
            pcWin.getCritical();
            return false;
        }
        if (pcWin.getReaction() == "")
        {
            pcWin.getReaction();
            return false;
        }
        if (pcWin.getMobility() == "")
        {
            pcWin.getMobility();
            return false;
        }
        if (pcWin.getFumble() == "")
        {
            pcWin.getFumble();
            return false;
        }
        if (pcWin.getExf() == "")
        {
            pcWin.getExf();
            return false;
        }
        if (pcWin.getExa() == "")
        {
            pcWin.getExa();
            return false;
        }

        PcParameter pc = new PcParameter();

        pc.Title = pcWin.getTitle();
        pc.PcName = pcWin.getPcName();

        pc.PcClass = pcWin.getPcClass();
        pc.Esprit = pcWin.getEsprit();

        pc.MaxHP = Int32.Parse(pcWin.getMaxHP());
        pc.MaxAP = Int32.Parse(pcWin.getMaxAP());
        pc.PAttack = Int32.Parse(pcWin.getPAttack());
        pc.MAttack = Int32.Parse(pcWin.getMAttack());
        pc.Exf = Int32.Parse(pcWin.getExf());
        pc.Defense = Int32.Parse(pcWin.getDefense());
        pc.Resist = Int32.Parse(pcWin.getResist());
        pc.Exa = Int32.Parse(pcWin.getExa());
        pc.Hits = Int32.Parse(pcWin.getHits());
        pc.Avoid = Int32.Parse(pcWin.getAvoid());
        pc.Critical = Int32.Parse(pcWin.getCritical());
        pc.Reaction = Int32.Parse(pcWin.getReaction());
        pc.Mobility = Int32.Parse(pcWin.getMobility());
        pc.Fumble = Int32.Parse(pcWin.getFumble());

        pc.Icon = pcWin.getIcon();

        Debug.Log("pcWin.activeSkillPanel1.SkillName.text:" + pcWin.getActiveSkillPanel1().getSkillName());
        if (!pcWin.getActiveSkillPanel1().getSkillName().Equals("")) {
            Debug.Log("getActiveSkill1");
            pc.Skill1 = getActiveSkill(pcWin.getActiveSkillPanel1());
        }
        if (!pcWin.getActiveSkillPanel2().getSkillName().Equals(""))
        {
            Debug.Log("getActiveSkill2");
            pc.Skill2 = getActiveSkill(pcWin.getActiveSkillPanel2());
        }
        if (!pcWin.getActiveSkillPanel3().getSkillName().Equals(""))
        {
            Debug.Log("getActiveSkill3");
            pc.Skill3 = getActiveSkill(pcWin.getActiveSkillPanel3());
        }
        if (!pcWin.getActiveSkillPanel4().getSkillName().Equals(""))
        {
            Debug.Log("getActiveSkill4");
            pc.Skill4 = getActiveSkill(pcWin.getActiveSkillPanel4());
        }

        PcParamList.Instance.pcs.Add(pc);
        
        return true;
    }

    private Skill getActiveSkill(ActiveSkillPanel asp)
    {
        Skill skill = null;

        if (asp.getEtc().Contains("自付与")) {
            EnchantSkill eSkill = new EnchantSkill(false);
            eSkill.IsMiner = true;

            string[] effectAr = setSkillBasicInfo(eSkill, asp).Split('、');

            PcParameter pcParam = getParam(effectAr);

            eSkill.Param = pcParam;

            skill = eSkill;
        }
        else if (asp.getEtc().Contains("【他者付与】"))
        {
            EnchantSkill eSkill = new EnchantSkill(true);

            string[] effectAr = setSkillBasicInfo(eSkill, asp).Split('、');

            PcParameter pcParam = getParam(effectAr);

            eSkill.Param = pcParam;

            skill = eSkill;
        }
        else if (asp.getEtc().Contains("回復"))
        {
            HealSkill hSkill = new HealSkill();

            string[] effectAr = setSkillBasicInfo(hSkill, asp).Split('、');

            for (int i = 0; i < effectAr.Length; i++)
            {
                Debug.Log(effectAr[i]);
                if (effectAr[i].Contains("HP回復"))
                {
                    hSkill.Hp = Int32.Parse(effectAr[i].Replace("HP回復", ""));
                    Debug.Log(hSkill.Hp);
                }
                if (effectAr[i].Contains("AP回復"))
                {
                    hSkill.Ap = Int32.Parse(effectAr[i].Replace("AP回復", ""));
                    Debug.Log(hSkill.Ap);
                }
                if (effectAr[i].Contains("BS回復"))
                {
                    hSkill.Bs = Int32.Parse(effectAr[i].Replace("BS回復", ""));
                    Debug.Log(hSkill.Bs);
                }
            }
            skill = hSkill;
        }
        else if (asp.getEtc().Contains("：AP"))
        {
            AttackSkill aSkill = new AttackSkill();

            string[] effectAr = setSkillBasicInfo(aSkill,asp).Split('、');

            for (int i = 0; i < effectAr.Length; i++)
            {
                if (effectAr[i].Contains("【"))
                {
                    if (!setBs(aSkill, effectAr[i]))
                    {
                        aSkill.EffectList.Add(effectAr[i]);
                        Debug.Log(effectAr[i]);
                    }
                }else if (effectAr[i].Contains("命中"))
                {
                    aSkill.Hits = Int32.Parse(effectAr[i].Replace("命中", ""));
                    Debug.Log(aSkill.Hits);
                }else if (effectAr[i].Contains("物攻"))
                {
                    string tmpStr = effectAr[i].Replace("物攻", "");
                    int a;
                    if (Int32.TryParse(tmpStr,out a)) {
                        aSkill.Power = Int32.Parse(effectAr[i].Replace("物攻", ""));
                        Debug.Log(aSkill.Power);
                    }
                    else
                    {
                        aSkill.Power = 3;
                        aSkill.EffectList.Add("【防技】");
                        Debug.Log("【防技】×" + aSkill.Power);
                    }
                }else if (effectAr[i].Contains("神攻"))
                {
                    aSkill.Power = Int32.Parse(effectAr[i].Replace("神攻", ""));
                    Debug.Log(aSkill.Power);
                }else if (effectAr[i].Contains("CT"))
                {
                    aSkill.Ct = Int32.Parse(effectAr[i].Replace("CT", ""));
                    Debug.Log(aSkill.Ct);
                }else if (effectAr[i].Contains("FB"))
                {
                    aSkill.Fb = Int32.Parse(effectAr[i].Replace("FB", ""));
                    Debug.Log(aSkill.Fb);
                }
                else
                {
                    aSkill.EffectList.Add(effectAr[i]);
                    Debug.Log(effectAr[i]);
                }
            }

            skill = aSkill;
        }

        return skill;
    }

    private bool setBs(AttackSkill aSkill, string text)
    {
        bool result = false;

        if (text.Contains("【毒】"))
        {
            aSkill.BsList.Add(new Poison1());
            result = true;
        }
        else if (text.Contains("【猛毒】"))
        {
            aSkill.BsList.Add(new Poison2());
            result = true;
        }
        else if (text.Contains("【死毒】"))
        {
            aSkill.BsList.Add(new Poison3());
            result = true;
        }
        else if (text.Contains("【火炎】"))
        {
            aSkill.BsList.Add(new Fire1());
            result = true;
        }
        else if (text.Contains("【業炎】"))
        {
            aSkill.BsList.Add(new Fire2());
            result = true;
        }
        else if (text.Contains("【炎獄】"))
        {
            aSkill.BsList.Add(new Fire3());
            result = true;
        }
        else if (text.Contains("【凍結】"))
        {
            aSkill.BsList.Add(new Ice1());
            result = true;
        }
        else if (text.Contains("【氷結】"))
        {
            aSkill.BsList.Add(new Ice2());
            result = true;
        }
        else if (text.Contains("【氷漬】"))
        {
            aSkill.BsList.Add(new Ice3());
            result = true;
        }
        else if (text.Contains("【痺れ】"))
        {
            aSkill.BsList.Add(new Shock1());
            result = true;
        }
        else if (text.Contains("【ショック】"))
        {
            aSkill.BsList.Add(new Shock2());
            result = true;
        }
        else if (text.Contains("【感電】"))
        {
            aSkill.BsList.Add(new Shock3());
            result = true;
        }
        else if (text.Contains("【乱れ】"))
        {
            aSkill.BsList.Add(new Disturbe1());
            result = true;
        }
        else if (text.Contains("【崩れ】"))
        {
            aSkill.BsList.Add(new Disturbe2());
            result = true;
        }
        else if (text.Contains("【体勢不利】"))
        {
            aSkill.BsList.Add(new Disturbe3());
            result = true;
        }
        else if (text.Contains("【出血】"))
        {
            aSkill.BsList.Add(new Bloody1());
            result = true;
        }
        else if (text.Contains("【流血】"))
        {
            aSkill.BsList.Add(new Bloody2());
            result = true;
        }
        else if (text.Contains("【失血】"))
        {
            aSkill.BsList.Add(new Bloody3());
            result = true;
        }
        else if (text.Contains("【窒息】"))
        {
            aSkill.BsList.Add(new Agony1());
            result = true;
        }
        else if (text.Contains("【苦鳴】"))
        {
            aSkill.BsList.Add(new Agony2());
            result = true;
        }
        else if (text.Contains("【懊悩】"))
        {
            aSkill.BsList.Add(new Agony3());
            result = true;
        }
        else if (text.Contains("【足止】"))
        {
            aSkill.BsList.Add(new Stasis1());
            result = true;
        }
        else if (text.Contains("【泥沼】"))
        {
            aSkill.BsList.Add(new Stasis2());
            result = true;
        }
        else if (text.Contains("【停滞】"))
        {
            aSkill.BsList.Add(new Stasis3());
            result = true;
        }


        else if (text.Contains("【不吉】"))
        {
            aSkill.BsList.Add(new Unluck1());
            result = true;
        }
        else if (text.Contains("【不運】"))
        {
            aSkill.BsList.Add(new Unluck2());
            result = true;
        }
        else if (text.Contains("【魔凶】"))
        {
            aSkill.BsList.Add(new Unluck3());
            result = true;
        }
        else if (text.Contains("【麻痺】"))
        {
            aSkill.BsList.Add(new Stop1());
            result = true;
        }
        else if (text.Contains("【呪縛】"))
        {
            aSkill.BsList.Add(new Stop2());
            result = true;
        }
        else if (text.Contains("【石化】"))
        {
            aSkill.BsList.Add(new Stop3());
            result = true;
        }
        else if (text.Contains("【混乱】"))
        {
            aSkill.BsList.Add(new Mind1());
            result = true;
        }
        else if (text.Contains("【狂気】"))
        {
            aSkill.BsList.Add(new Mind2());
            result = true;
        }
        else if (text.Contains("【魅了】"))
        {
            aSkill.BsList.Add(new Mind3());
            result = true;
        }
        else if (text.Contains("【呪い】"))
        {
            aSkill.BsList.Add(new Curse());
            result = true;
        }
        else if (text.Contains("【致命】"))
        {
            aSkill.BsList.Add(new Fatal());
            result = true;
        }
        else if (text.Contains("【封印】"))
        {
            aSkill.BsList.Add(new Seale());
            result = true;
        }
        else if (text.Contains("【暗闇】"))
        {
            aSkill.BsList.Add(new Dark());
            result = true;
        }
        else if (text.Contains("【恍惚】"))
        {
            aSkill.BsList.Add(new Trance());
            result = true;
        }
        else if (text.Contains("【怒り】"))
        {
            aSkill.BsList.Add(new Hate());
            result = true;
        }

        return result;
    }

        private string setSkillBasicInfo(Skill skill, ActiveSkillPanel asp)
    {
        skill.setName(asp.getSkillName());
        skill.Etc = asp.getEtc();
        Debug.Log("skill.Etc:" + skill.Etc);

        string[] etcAr = asp.getEtc().Trim().Split('：');

        skill.Basic = etcAr[0];
        skill.UseAp = Int32.Parse(etcAr[1].Replace("AP", ""));

        return etcAr[2];
    }

    private PcParameter getParam(string[] effectAr)
    {
        PcParameter param = new PcParameter();


        for (int i = 0; i < effectAr.Length; i++)
        {
            string tempStr = effectAr[i].Replace("レンジ2以内の味方の", "");

            if (tempStr.Contains("命中"))
            {
                param.Hits = Int32.Parse(tempStr.Replace("命中", ""));
                Debug.Log(param.Hits);
            }else if (tempStr.Contains("物攻"))
            {
                param.PAttack = Int32.Parse(tempStr.Replace("物攻", ""));
                Debug.Log(param.PAttack);
            }else if (tempStr.Contains("神攻"))
            {
                param.MAttack = Int32.Parse(tempStr.Replace("神攻", ""));
                Debug.Log(param.MAttack);
            }else if (tempStr.Contains("CT"))
            {
                param.Critical = Int32.Parse(tempStr.Replace("CT", ""));
                Debug.Log(param.Critical);
            }else if (tempStr.Contains("FB"))
            {
                param.Fumble = Int32.Parse(tempStr.Replace("FB", ""));
                Debug.Log(param.Fumble);
            }
            else if (tempStr.Contains("防技"))
            {
                param.Defense = Int32.Parse(tempStr.Replace("防技", ""));
                Debug.Log(param.Defense);
            }
            else if (tempStr.Contains("抵抗"))
            {
                param.Resist = Int32.Parse(tempStr.Replace("抵抗", ""));
                Debug.Log(param.Resist);
            }
            else if (tempStr.Contains("EXF"))
            {
                param.Exf = Int32.Parse(tempStr.Replace("EXF", ""));
                Debug.Log(param.Exf);
            }
            else if (tempStr.Contains("EXA"))
            {
                param.Exa = Int32.Parse(tempStr.Replace("EXA", ""));
                Debug.Log(param.Exa);
            }
            else if (tempStr.Contains("反応"))
            {
                param.Reaction = Int32.Parse(tempStr.Replace("反応", ""));
                Debug.Log(param.Reaction);
            }
            else if (tempStr.Contains("機動力"))
            {
                param.Mobility = Int32.Parse(tempStr.Replace("機動力", ""));
                Debug.Log(param.Mobility);
            }

        }

        return param;
    }
}
