using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSkillPanel : MonoBehaviour {

    private InputField SkillName;

    private InputField UseAP;

    private InputField Power;

    private InputField Hits;

    private InputField Ct;

    private InputField Fb;

    // Use this for initialization
    void Start () {
        SkillName = transform.Find("SkillNameInputField").GetComponent<InputField>();
        UseAP = transform.Find("UseAPInputField").GetComponent<InputField>();
        Power = transform.Find("PowerInputField").GetComponent<InputField>();
        Hits = transform.Find("HitsInputField").GetComponent<InputField>();
        Ct = transform.Find("CTInputField").GetComponent<InputField>();
        Fb = transform.Find("FBInputField").GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getSkillName()
    {
        return SkillName.text;
    }

    public string getUseAP()
    {
        return UseAP.text;
    }

    public string getPower()
    {
        return Power.text;
    }

    public string getHits()
    {
        return Hits.text;
    }

    public string getCt()
    {
        return Ct.text;
    }

    public string getFb()
    {
        return Fb.text;
    }

    public void setSkillName(string value)
    {
        SkillName.text = value;
    }

    public void setUseAP(string value)
    {
        UseAP.text = value;
    }

    public void setPower(string value)
    {
        Power.text = value;
    }

    public void setHits(string value)
    {
        Hits.text = value;
    }

    public void setCt(string value)
    {
        Ct.text = value;
    }

    public void setFb(string value)
    {
        Fb.text = value;
    }

    public void init()
    {
        SkillName.text = "";
        UseAP.text = "";
        Power.text = "";
        Hits.text = "";
        Ct.text = "";
        Fb.text = "";
    }
}
