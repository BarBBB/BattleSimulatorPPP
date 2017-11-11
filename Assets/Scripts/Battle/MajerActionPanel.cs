using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajerActionPanel : MonoBehaviour {

    public PlayerCharacter MajerActionPc = null;

    public ActionButton NomalAttackButton;

    public SkillAttackButton SkillAttackButton;

    public FullAttackButton FullAttackButton;

    public ActionButton FullDefenseButton;

    public ActionButton FullMoveButton;

    public ActionButton BlockButton;

    public ActionButton CoverUpButton;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void init(PlayerCharacter pc)
    {
        MajerActionPc = pc;
        FullAttackButton.init();
    }
}
