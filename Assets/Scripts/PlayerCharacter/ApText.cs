using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApText : MonoBehaviour {

    public int CurrentAp;
    public int MaxAp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "HP：" + CurrentAp + "/" + MaxAp;
    }
}
