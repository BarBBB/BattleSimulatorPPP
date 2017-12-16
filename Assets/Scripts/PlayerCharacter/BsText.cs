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
            int count = BadStatus.START_COUNT - bs.getCount();
            string bsStr = bs.getName() + "(" + count + ")";
            if (bsText == "")
            {
                bsText = bsStr;
            }
            else
            {
                bsText += "," + bsStr;
            }
        }

        this.GetComponent<Text>().text = "BS：" + bsText;
    }
}
