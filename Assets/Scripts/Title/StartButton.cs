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
        Skill skill = new Skill();

        skill.Name = asp.getSkillName();
        //skill.UseAp = Int32.Parse(asp.getUseAP());
        //skill.Power = Int32.Parse(asp.getPower());
        //skill.Hits = Int32.Parse(asp.getHits());
        //skill.Ct = Int32.Parse(asp.getCt());
        //skill.Fb = Int32.Parse(asp.getFb());

        return skill;
    }
}
