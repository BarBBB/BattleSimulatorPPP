using UnityEngine;
using UnityEngine.UI;

public class PcInputWindow : MonoBehaviour {

    private InputManager Title;

    private InputManager PcName;

    private InputManager PcClass;

    private InputManager Esprit;

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

        PcClass = canvas.Find("ClassPanel").Find("ClassInputField").GetComponent<InputManager>();
        Esprit = canvas.Find("EspritPanel").Find("EspritInputField").GetComponent<InputManager>();

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

        PcClass.setInputField(pcParam.PcClass);
        Esprit.setInputField(pcParam.Esprit);

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

        if (pcParam.Skill1 != null)
        {
            activeSkillPanel1.setSkillName(pcParam.Skill1.Name);
            activeSkillPanel1.setEtc(pcParam.Skill1.Etc);
        }
        if (pcParam.Skill2 != null)
        {
            activeSkillPanel2.setSkillName(pcParam.Skill2.Name);
            activeSkillPanel2.setEtc(pcParam.Skill2.Etc);
        }
        if (pcParam.Skill3 != null)
        {
            activeSkillPanel3.setSkillName(pcParam.Skill3.Name);
            activeSkillPanel3.setEtc(pcParam.Skill3.Etc);
        }
        if (pcParam.Skill4 != null)
        {
            activeSkillPanel4.setSkillName(pcParam.Skill4.Name);
            activeSkillPanel4.setEtc(pcParam.Skill4.Etc);
        }
    }

    public void setPcIcon(Texture pcIcon)
    {
        icon.texture = pcIcon;
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
