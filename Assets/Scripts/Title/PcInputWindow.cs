using UnityEngine;
using UnityEngine.UI;

public class PcInputWindow : MonoBehaviour {

    private InputManager Title;

    private InputManager PcName;

    private InputManager MaxHP;

    private InputManager MaxAP;

    private InputManager PAttack;

    private InputManager MAttack;

    private InputManager Defense;

    private InputManager Resist;

    private InputManager Hits;

    private InputManager Avoid;

    private InputManager Critical;

    private InputManager Reaction;

    private InputManager Mobility;

    private InputManager Fumble;

    private InputManager Exf;

    private InputManager Exa;

    private RawImage icon;

    private string IconURL = null;

    private ActiveSkillPanel activeSkillPanel1;

    private ActiveSkillPanel activeSkillPanel2;

    private ActiveSkillPanel activeSkillPanel3;

    private ActiveSkillPanel activeSkillPanel4;


    void Start()
    {
        Transform canvas = transform.Find("Canvas");

        Title = canvas.Find("TitlePanel").Find("TitleInputField").GetComponent<InputManager>();
        PcName = canvas.Find("NamePanel").Find("NameInputField").GetComponent<InputManager>();
        MaxHP = canvas.Find("MaxHpPanel").Find("MaxHpInputField").GetComponent<InputManager>();
        MaxAP = canvas.Find("MaxApPanel").Find("MaxApInputField").GetComponent<InputManager>();
        PAttack = canvas.Find("PAttackPanel").Find("PAttackInputField").GetComponent<InputManager>();
        MAttack = canvas.Find("MAttackPanel").Find("MAttackInputField").GetComponent<InputManager>();
        Defense = canvas.Find("DefensePanel").Find("DefenseInputField").GetComponent<InputManager>();
        Resist = canvas.Find("ResistPanel").Find("ResistInputField").GetComponent<InputManager>();
        Hits = canvas.Find("HitsPanel").Find("HitsInputField").GetComponent<InputManager>();
        Avoid = canvas.Find("AvoidPanel").Find("AvoidInputField").GetComponent<InputManager>();
        Critical = canvas.Find("CriticalPanel").Find("CriticalInputField").GetComponent<InputManager>();
        Reaction = canvas.Find("ReactionPanel").Find("ReactionInputField").GetComponent<InputManager>();
        Mobility = canvas.Find("MobilityPanel").Find("MobilityInputField").GetComponent<InputManager>();
        Fumble = canvas.Find("FumblelPanel").Find("FumblelInputField").GetComponent<InputManager>();
        Exf = canvas.Find("ExfPanel").Find("ExfInputField").GetComponent<InputManager>();
        Exa = canvas.Find("ExaPanel").Find("ExaInputField").GetComponent<InputManager>();

        icon = canvas.Find("Icon").GetComponent<RawImage>();

        Transform skillListPanel = canvas.Find("SkillListPanel");
        activeSkillPanel1 = skillListPanel.Find("ActiveSkillPanel1").GetComponent<ActiveSkillPanel>();
        activeSkillPanel2 = skillListPanel.Find("ActiveSkillPanel2").GetComponent<ActiveSkillPanel>();
        activeSkillPanel3 = skillListPanel.Find("ActiveSkillPanel3").GetComponent<ActiveSkillPanel>();
        activeSkillPanel4 = skillListPanel.Find("ActiveSkillPanel4").GetComponent<ActiveSkillPanel>();
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

        activeSkillPanel1.setSkillName("TestSkill1");
        activeSkillPanel1.setUseAP("10");
        activeSkillPanel1.setPower("255");
        activeSkillPanel1.setHits("15");
        activeSkillPanel1.setCt("5");
        activeSkillPanel1.setFb("15");

        activeSkillPanel2.setSkillName("TestSkill2");
        activeSkillPanel2.setUseAP("200");
        activeSkillPanel2.setPower("355");
        activeSkillPanel2.setHits("25");
        activeSkillPanel2.setCt("5");
        activeSkillPanel2.setFb("15");

        activeSkillPanel3.setSkillName("TestSkill3");
        activeSkillPanel3.setUseAP("30");
        activeSkillPanel3.setPower("455");
        activeSkillPanel3.setHits("35");
        activeSkillPanel3.setCt("5");
        activeSkillPanel3.setFb("15");

        activeSkillPanel4.setSkillName("TestSkill4");
        activeSkillPanel4.setUseAP("100");
        activeSkillPanel4.setPower("555");
        activeSkillPanel4.setHits("45");
        activeSkillPanel4.setCt("5");
        activeSkillPanel4.setFb("15");
    }

    public string getTitle()
    {
        return Title.getInputField();
    }

    public string getPcName()
    {
        return PcName.getInputField();
    }

    public string getMaxHP()
    {
        return MaxHP.getInputField();
    }

    public string getMaxAP()
    {
        return MaxAP.getInputField();
    }

    public string getPAttack()
    {
        return PAttack.getInputField();
    }

    public string getMAttack()
    {
        return MAttack.getInputField();
    }

    public string getDefense()
    {
        return Defense.getInputField();
    }

    public string getResist()
    {
        return Resist.getInputField();
    }

    public string getHits()
    {
        return Hits.getInputField();
    }

    public string getAvoid()
    {
        return Avoid.getInputField();
    }

    public string getCritical()
    {
        return Critical.getInputField();
    }

    public string getReaction()
    {
        return Reaction.getInputField();
    }

    public string getMobility()
    {
        return Mobility.getInputField();
    }

    public string getFumble()
    {
        return Fumble.getInputField();
    }

    public string getExf()
    {
        return Exf.getInputField();
    }

    public string getExa()
    {
        return Exa.getInputField();
    }

    public string getIconURL()
    {
        return IconURL;
    }

    public void setIconURL(string url)
    {
        IconURL = url;
    }

    public ActiveSkillPanel getActiveSkillPanel1()
    {
        return activeSkillPanel1;
    }

    public ActiveSkillPanel getActiveSkillPanel2()
    {
        return activeSkillPanel2;
    }

    public ActiveSkillPanel getActiveSkillPanel3()
    {
        return activeSkillPanel3;
    }

    public ActiveSkillPanel getActiveSkillPanel4()
    {
        return activeSkillPanel4;
    }

    public RawImage getIcon()
    {
        return icon;
    }

    public void init()
    {
        Title.setInputField("");
        PcName.setInputField("");
        MaxHP.setInputField("");
        MaxAP.setInputField("");
        PAttack.setInputField("");
        MAttack.setInputField("");
        Defense.setInputField("");
        Resist.setInputField("");
        Hits.setInputField("");
        Avoid.setInputField("");
        Critical.setInputField("");
        Reaction.setInputField("");
        Mobility.setInputField("");
        Fumble.setInputField("");
        Exf.setInputField("");
        Exa.setInputField("");

        icon = null;
        IconURL = null;

        activeSkillPanel1.init();
        activeSkillPanel2.init();
        activeSkillPanel3.init();
        activeSkillPanel4.init();
    }
}
