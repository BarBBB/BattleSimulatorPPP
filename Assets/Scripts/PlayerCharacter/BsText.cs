using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BsText : MonoBehaviour {

    public List<BadStatus> BsList = new List<BadStatus>();

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        string bsText = "";

        foreach (BadStatus bs in BsList)
        {
            if (bsText == "")
            {
                bsText = bs.getName();
            }
            else
            {
                bsText += "," + bs.getName();
            }
        }

        this.GetComponent<Text>().text = "BS：" + bsText;
    }
}
