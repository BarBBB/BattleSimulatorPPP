using UnityEngine;

public class SkillAttackButton : MonoBehaviour {

    public MajerActionPanel MajorActionPanel;

    public GameObject SkillPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (SkillPanel.activeSelf)
        {
            SkillPanel.SetActive(false);
        }
        else
        {
            SkillPanel.SetActive(true);
            Debug.Log(this);
            PlayerCharacter pc = MajorActionPanel.MajerActionPc;
            SkillPanel sp = SkillPanel.GetComponent<SkillPanel>();
            sp.ReadyWiindow(pc);
        }
    }
}
