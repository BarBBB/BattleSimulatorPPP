using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour {

    public PcParameter pcParam = null;

    public SkillButton SkillButton1;

    public SkillButton SkillButton2;

    public SkillButton SkillButton3;

    public SkillButton SkillButton4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReadyWiindow(PlayerCharacter pc, int ap)
    {
         pcParam = pc.baseParam;

        if (pcParam.Skill1 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill1, ap);
        }
        if (pcParam.Skill2 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill2, ap);
        }
        if (pcParam.Skill3 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill3, ap);
        }
        if (pcParam.Skill4 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill4, ap);
        }
    }
}
