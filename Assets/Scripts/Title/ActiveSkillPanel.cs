using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSkillPanel : MonoBehaviour {

    private InputField SkillName;

    private InputField Etc;


    // Use this for initialization
    void Start () {
        SkillName = transform.Find("SkillNameInputField").GetComponent<InputField>();
        Etc = transform.Find("SkillEtcInputField").GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getSkillName()
    {
        return SkillName.text;
    }

    public string getEtc()
    {
        return Etc.text;
    }

    public void setSkillName(string value)
    {
        SkillName.text = value;
    }

    public void setEtc(string value)
    {
        Etc.text = value;
    }

    public void init()
    {
        SkillName.text = "";
        Etc.text = "";
    }
}
