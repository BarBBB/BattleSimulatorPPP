using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BsText : MonoBehaviour {

    public List<string> BsList = new List<string>();

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        string bsText = "";

        foreach (string bs in BsList)
        {
            if (bsText == "")
            {
                bsText = bs;
            }
            else
            {
                bsText += "," + bs;
            }
        }

        this.GetComponent<Text>().text = "BS：" + bsText;
    }
}
