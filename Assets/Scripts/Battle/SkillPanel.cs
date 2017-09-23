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

    public void ReadyWiindow(PlayerCharacter pc)
    {
        Debug.Log(this);
        pcParam = pc.baseParam;
        Debug.Log(pcParam.Skill1);
        if (pcParam.Skill1 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill1, pc.Ap.CurrentAp);
        }
        if (pcParam.Skill2 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill2, pc.Ap.CurrentAp);
        }
        if (pcParam.Skill3 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill3, pc.Ap.CurrentAp);
        }
        if (pcParam.Skill4 != null)
        {
            SkillButton1.ReadyButton(pcParam.Skill4, pc.Ap.CurrentAp);
        }
    }
}
