using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    private GameObject requirePanel;

    public PcInputWindow pcWin1;
    public PcInputWindow pcWin2;

    // Use this for initialization
    void Start () {
        Debug.Log(this);
        
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
        if (pcWin.PcName.getInputField() == "")
        {
            pcWin.PcName.setActivateInputField();
            return false;
        }
        if (pcWin.MaxHP.getInputField() == "")
        {
            pcWin.MaxHP.setActivateInputField();
            return false;
        }
        if (pcWin.MaxAP.getInputField() == "")
        {
            pcWin.MaxAP.setActivateInputField();
            return false;
        }
        if (pcWin.PAttack.getInputField() == "")
        {
            pcWin.PAttack.setActivateInputField();
            return false;
        }
        if (pcWin.MAttack.getInputField() == "")
        {
            pcWin.MAttack.setActivateInputField();
            return false;
        }
        if (pcWin.Defense.getInputField() == "")
        {
            pcWin.Defense.setActivateInputField();
            return false;
        }
        if (pcWin.Resist.getInputField() == "")
        {
            pcWin.Resist.setActivateInputField();
            return false;
        }
        if (pcWin.Hits.getInputField() == "")
        {
            pcWin.Hits.setActivateInputField();
            return false;
        }
        if (pcWin.Avoid.getInputField() == "")
        {
            pcWin.Avoid.setActivateInputField();
            return false;
        }
        if (pcWin.Critical.getInputField() == "")
        {
            pcWin.Critical.setActivateInputField();
            return false;
        }
        if (pcWin.Reaction.getInputField() == "")
        {
            pcWin.Reaction.setActivateInputField();
            return false;
        }
        if (pcWin.Mobility.getInputField() == "")
        {
            pcWin.Mobility.setActivateInputField();
            return false;
        }
        if (pcWin.Fumble.getInputField() == "")
        {
            pcWin.Fumble.setActivateInputField();
            return false;
        }
        if (pcWin.Exf.getInputField() == "")
        {
            pcWin.Exf.setActivateInputField();
            return false;
        }
        if (pcWin.Exa.getInputField() == "")
        {
            pcWin.Exa.setActivateInputField();
            return false;
        }

        PcParameter pc = new PcParameter();

        pc.Title = pcWin.Title.getInputField();
        pc.PcName = pcWin.PcName.getInputField();
        
        pc.MaxHP = Int32.Parse(pcWin.MaxHP.getInputField());
        pc.MaxAP = Int32.Parse(pcWin.MaxAP.getInputField());
        pc.PAttack = Int32.Parse(pcWin.PAttack.getInputField());
        pc.MAttack = Int32.Parse(pcWin.MAttack.getInputField());
        pc.Exf = Int32.Parse(pcWin.Exf.getInputField());
        pc.Defense = Int32.Parse(pcWin.Defense.getInputField());
        pc.Resist = Int32.Parse(pcWin.Resist.getInputField());
        pc.Exa = Int32.Parse(pcWin.Exa.getInputField());
        pc.Hits = Int32.Parse(pcWin.Hits.getInputField());
        pc.Avoid = Int32.Parse(pcWin.Avoid.getInputField());
        pc.Critical = Int32.Parse(pcWin.Critical.getInputField());
        pc.Reaction = Int32.Parse(pcWin.Reaction.getInputField());
        pc.Mobility = Int32.Parse(pcWin.Mobility.getInputField());
        pc.Fumble = Int32.Parse(pcWin.Fumble.getInputField());

        pc.Icon = pcWin.icon;

        Debug.Log("pcWin.activeSkillPanel1.SkillName.text:" + pcWin.activeSkillPanel1.SkillName.text);
        if (!pcWin.activeSkillPanel1.SkillName.text.Equals("")) {
            Debug.Log("getActiveSkill1");
            pc.Skill1 = getActiveSkill(pcWin.activeSkillPanel1);
        }
        if (!pcWin.activeSkillPanel2.SkillName.text.Equals(""))
        {
            Debug.Log("getActiveSkill2");
            pc.Skill2 = getActiveSkill(pcWin.activeSkillPanel2);
        }
        if (!pcWin.activeSkillPanel3.SkillName.text.Equals(""))
        {
            Debug.Log("getActiveSkill3");
            pc.Skill3 = getActiveSkill(pcWin.activeSkillPanel3);
        }
        if (!pcWin.activeSkillPanel4.SkillName.text.Equals(""))
        {
            Debug.Log("getActiveSkill4");
            pc.Skill4 = getActiveSkill(pcWin.activeSkillPanel4);
        }

        PcParamList.Instance.pcs.Add(pc);
        
        return true;
    }

    private Skill getActiveSkill(ActiveSkillPanel asp)
    {
        Skill skill = new Skill();

        skill.Name = asp.SkillName.text;
        skill.UseAp = Int32.Parse(asp.UseAP.text);
        skill.Power = Int32.Parse(asp.Power.text);
        skill.Hits = Int32.Parse(asp.Hits.text);
        skill.Ct = Int32.Parse(asp.Ct.text);
        skill.Fb = Int32.Parse(asp.Fb.text);

        return skill;
    }
}
