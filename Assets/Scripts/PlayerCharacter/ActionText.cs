using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionText : MonoBehaviour {

    public List<string> ActionList = new List<string>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string actionText = "";

        foreach (string action in ActionList)
        {
            if (actionText == "")
            {
                actionText = action;
            }
            else
            {
                actionText += "," + action;
            }
        }

        this.GetComponent<Text>().text = "宣言：" + actionText;
    }
}
