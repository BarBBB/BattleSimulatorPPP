using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    private GameObject requirePanel;

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
        PcInputWindow pcWin1 = GameObject.Find("PcInputWindow1").GetComponent<PcInputWindow>();
        PcInputWindow pcWin2 = GameObject.Find("PcInputWindow2").GetComponent<PcInputWindow>();

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
        if (pcWin.Title.inputField.text == "")
        {
            pcWin.Title.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.PcName.inputField.text == "")
        {
            pcWin.PcName.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.MaxHP.inputField.text == "")
        {
            pcWin.MaxHP.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.MaxAP.inputField.text == "")
        {
            pcWin.MaxAP.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.PAttack.inputField.text == "")
        {
            pcWin.PAttack.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.MAttack.inputField.text == "")
        {
            pcWin.MAttack.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Defense.inputField.text == "")
        {
            pcWin.Defense.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Resist.inputField.text == "")
        {
            pcWin.Resist.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Hits.inputField.text == "")
        {
            pcWin.Hits.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Avoid.inputField.text == "")
        {
            pcWin.Avoid.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Critical.inputField.text == "")
        {
            pcWin.Critical.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Reaction.inputField.text == "")
        {
            pcWin.Reaction.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Mobility.inputField.text == "")
        {
            pcWin.Mobility.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Fumble.inputField.text == "")
        {
            pcWin.Fumble.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Exf.inputField.text == "")
        {
            pcWin.Exf.inputField.ActivateInputField();
            return false;
        }
        if (pcWin.Exa.inputField.text == "")
        {
            pcWin.Exa.inputField.ActivateInputField();
            return false;
        }

        PcParameter pc = new PcParameter();

        pc.Title = pcWin.Title.inputField.text;
        pc.PcName = pcWin.PcName.inputField.text;
        
        pc.MaxHP = Int32.Parse(pcWin.MaxHP.inputField.text);
        pc.MaxAP = Int32.Parse(pcWin.MaxAP.inputField.text);
        pc.PAttack = Int32.Parse(pcWin.PAttack.inputField.text);
        pc.MAttack = Int32.Parse(pcWin.MAttack.inputField.text);
        pc.Exf = Int32.Parse(pcWin.Exf.inputField.text);
        pc.Defense = Int32.Parse(pcWin.Defense.inputField.text);
        pc.Resist = Int32.Parse(pcWin.Resist.inputField.text);
        pc.Exa = Int32.Parse(pcWin.Exa.inputField.text);
        pc.Hits = Int32.Parse(pcWin.Hits.inputField.text);
        pc.Avoid = Int32.Parse(pcWin.Avoid.inputField.text);
        pc.Critical = Int32.Parse(pcWin.Critical.inputField.text);
        pc.Reaction = Int32.Parse(pcWin.Reaction.inputField.text);
        pc.Mobility = Int32.Parse(pcWin.Mobility.inputField.text);
        pc.Fumble = Int32.Parse(pcWin.Fumble.inputField.text);

        PcParamList.Instance.pcs.Add(pc);
        
        return true;
    }
}
