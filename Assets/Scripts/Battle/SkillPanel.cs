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

    public void ReadyWiindow(PlayerCharacter pc, bool isMinor)
    {
        Debug.Log(this);

        if (pc.Bs.BsList.Find(x => x.getName().Equals("封印")) == null)
        {
            if (pc.Skill1 != null)
            {
                SkillButton1.ReadyButton(pc.Skill1, pc.Ap.CurrentAp, isMinor);
            }
            else
            {
                SkillButton1.ResetButton();
            }
            if (pc.Skill2 != null)
            {
                SkillButton2.ReadyButton(pc.Skill2, pc.Ap.CurrentAp, isMinor);
            }
            else
            {
                SkillButton2.ResetButton();
            }
            if (pc.Skill3 != null)
            {
                SkillButton3.ReadyButton(pc.Skill3, pc.Ap.CurrentAp, isMinor);
            }
            else
            {
                SkillButton3.ResetButton();
            }
            if (pc.Skill4 != null)
            {
                SkillButton4.ReadyButton(pc.Skill4, pc.Ap.CurrentAp, isMinor);
            }
            else
            {
                SkillButton4.ResetButton();
            }
        }
    }
}
