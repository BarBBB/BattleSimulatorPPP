using UnityEngine;

public class MinorSkillButton : MonoBehaviour {

    public MinorActionPanel MajorActionPanel;

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
            PlayerCharacter pc = MajorActionPanel.MinorActionPc;

            SkillPanel sp = SkillPanel.GetComponent<SkillPanel>();
            sp.ReadyWiindow(pc, true);
        }
    }
}
