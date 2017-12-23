using UnityEngine;
using UnityEngine.UI;

public class SkillButton : ActionButton
{

    public Text text;

    const string HEADER = "[AP:";

    const string SPLIT = "]";

    private Skill thisSkil;

    public void ReadyButton(Skill skill, int ap)
    {
        Debug.Log(this);
        thisSkil = skill;

        text.text = HEADER + skill.UseAp + SPLIT + skill.getName();
        Debug.Log(text.text);
        Button bt = this.GetComponent<Button>();

        if (skill.UseAp <= ap)
        {
            bt.interactable = true;
        }
        else
        {
            bt.interactable = false;
        }
    }

    public void ResetButton()
    {
        thisSkil = null;
        text.text = "";

        Button bt = this.GetComponent<Button>();
        bt.interactable = false;
    }

    public new void OnClick()
    {
        battleEngine.buttonClickAction(ActionManage.SKILL_ATTACK, thisSkil);
    }
}
