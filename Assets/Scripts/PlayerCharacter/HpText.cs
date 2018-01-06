using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour {

    private int currentHp;
    private int maxHp;

    public int CurrentHp
    {
        get {
            return currentHp;
        }
        set {
            currentHp = value;
            if (currentHp > maxHp)
            {
                currentHp = maxHp;
            }
        }
    }
    public int MaxHp
    {
        get {
            return maxHp;
        }
        set {
            maxHp = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "HP：" + CurrentHp + "/" + MaxHp;
    }
}
