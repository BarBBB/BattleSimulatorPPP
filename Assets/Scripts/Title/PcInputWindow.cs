using UnityEngine;
using UnityEngine.UI;

public class PcInputWindow : MonoBehaviour {

    public InputManager Title;

    public InputManager PcName;

    public InputManager MaxHP;

    public InputManager MaxAP;

    public InputManager PAttack;

    public InputManager MAttack;

    public InputManager Defense;

    public InputManager Resist;

    public InputManager Hits;

    public InputManager Avoid;

    public InputManager Critical;

    public InputManager Reaction;

    public InputManager Mobility;

    public InputManager Fumble;

    public InputManager Exf;

    public InputManager Exa;

    public RawImage icon;

    public string IconURL = null;

    public ActiveSkillPanel activeSkillPanel1;

    public ActiveSkillPanel activeSkillPanel2;

    public ActiveSkillPanel activeSkillPanel3;

    public ActiveSkillPanel activeSkillPanel4;


    void Start()
    {
    }

    public void setPcParameter(PcParameter pcParam)
    {
        Title.setInputField(pcParam.Title);
        PcName.setInputField(pcParam.PcName);
        MaxHP.setInputField(pcParam.MaxHP.ToString());
        MaxAP.setInputField(pcParam.MaxAP.ToString());
        PAttack.setInputField(pcParam.PAttack.ToString());
        MAttack.setInputField(pcParam.MAttack.ToString());
        Exf.setInputField(pcParam.Exf.ToString());
        Defense.setInputField(pcParam.Defense.ToString());
        Resist.setInputField(pcParam.Resist.ToString());
        Exa.setInputField(pcParam.Exa.ToString());
        Hits.setInputField(pcParam.Hits.ToString());
        Avoid.setInputField(pcParam.Avoid.ToString());
        Critical.setInputField(pcParam.Critical.ToString());
        Reaction.setInputField(pcParam.Reaction.ToString());
        Mobility.setInputField(pcParam.Mobility.ToString());
        Fumble.setInputField(pcParam.Fumble.ToString());
    }

    public void setPcIcon(Texture pcIcon)
    {
        icon.texture = pcIcon;
    }

    public void setSukill()
    {
        Debug.Log("setSukill");

        activeSkillPanel1.SkillName.text = "TestSkill1";
        activeSkillPanel1.UseAP.text = "10";
        activeSkillPanel1.Power.text = "255";
        activeSkillPanel1.Hits.text = "15";
        activeSkillPanel1.Ct.text = "5";
        activeSkillPanel1.Fb.text = "15";

        activeSkillPanel2.SkillName.text = "TestSkill2";
        activeSkillPanel2.UseAP.text = "200";
        activeSkillPanel2.Power.text = "355";
        activeSkillPanel2.Hits.text = "25";
        activeSkillPanel2.Ct.text = "5";
        activeSkillPanel2.Fb.text = "15";

        activeSkillPanel3.SkillName.text = "TestSkill3";
        activeSkillPanel3.UseAP.text = "30";
        activeSkillPanel3.Power.text = "455";
        activeSkillPanel3.Hits.text = "35";
        activeSkillPanel3.Ct.text = "5";
        activeSkillPanel3.Fb.text = "15";

        activeSkillPanel4.SkillName.text = "TestSkill4";
        activeSkillPanel4.UseAP.text = "100";
        activeSkillPanel4.Power.text = "555";
        activeSkillPanel4.Hits.text = "45";
        activeSkillPanel4.Ct.text = "5";
        activeSkillPanel4.Fb.text = "15";
    }
}
