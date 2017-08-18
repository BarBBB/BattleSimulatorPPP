using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantText : MonoBehaviour {

    public List<string> EnchantList = new List<string>();

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        string enchantText = "";

        foreach (string enchant in EnchantList)
        {
            if (enchantText == "")
            {
                enchantText = enchant;
            }
            else
            {
                enchantText += "," + enchant;
            }
        }

        this.GetComponent<Text>().text = "付与：" + enchantText;
    }
}
