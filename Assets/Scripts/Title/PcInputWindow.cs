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
}
