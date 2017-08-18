using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour {

    private PcInputWindow window;

    // Use this for initialization
    void Start () {
        Debug.Log(this);
        window = transform.parent.parent.GetComponent<PcInputWindow>();
    }

    public void OnClick()
    {
        window.Title.InitInputField();
        window.PcName.InitInputField();
        window.MaxHP.InitInputField();
        window.MaxAP.InitInputField();
        window.PAttack.InitInputField();
        window.MAttack.InitInputField();
        window.Defense.InitInputField();
        window.Resist.InitInputField();
        window.Hits.InitInputField();
        window.Avoid.InitInputField();
        window.Critical.InitInputField();
        window.Reaction.InitInputField();
        window.Mobility.InitInputField();
        window.Fumble.InitInputField();
        window.Exf.InitInputField();
        window.Exa.InitInputField();
    }
}
