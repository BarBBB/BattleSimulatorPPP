using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApText : MonoBehaviour {

    private int currentAp;
    private int maxAp;

    public int CurrentAp {
        get {
            return currentAp;
        }
        set {
            currentAp = value;
            if (currentAp > maxAp)
            {
                currentAp = maxAp;
            }
            else if (currentAp < 0)
            {
                currentAp = 0;
            }
        }
    }
    public int MaxAp {
        get
        {
            return maxAp;
        }
        set
        {
            maxAp = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "AP：" + CurrentAp + "/" + MaxAp;
    }
}
