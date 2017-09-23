using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public Text text;

    const string HEADER = "[AP:";

    const string SPLIT = "]";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadyButton(Skill skill, int ap)
    {
        Debug.Log(this);
        text.text = HEADER + skill.UseAp + SPLIT + skill.Name;
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
}
