using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinorActionPanel : MonoBehaviour {

    public PlayerCharacter MinorActionPc = null;

    public ActionButton MoveButton;

    public ActionButton AttackConcentButton;

    public ActionButton DefenseConcentButton;

    public ActionButton MarkButton;

    public ActionButton MinorSkillButton;

    public ActionButton BaseActionButton;

    public RawImage icon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void init(PlayerCharacter pc)
    {
        MinorActionPc = pc;
        icon.texture = pc.icon.texture;
    }
}
