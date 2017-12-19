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

    //public int getPAttack()
    //{
    //    return baseParam.PAttack + paramCorrect.PAttack;
    //}
    //public int getMAttack()
    //{
    //    return baseParam.MAttack + paramCorrect.MAttack;
    //}
    //public int getExf()
    //{
    //    return baseParam.Exf + paramCorrect.Exf;
    //}
    //public int getDefense()
    //{
    //    return baseParam.Defense + paramCorrect.Defense;
    //}
    //public int getResist()
    //{
    //    return baseParam.Resist + paramCorrect.Resist;
    //}
    //public int getExa()
    //{
    //    return baseParam.Exa + paramCorrect.Exa;
    //}
    //public int getHits()
    //{
    //    return baseParam.Hits + paramCorrect.Hits;
    //}
    //public int getAvoid()
    //{
    //    return baseParam.Avoid + paramCorrect.Avoid;
    //}
    //public int getCritical()
    //{
    //    return baseParam.Critical + paramCorrect.Critical;
    //}
    //public int getRaction()
    //{
    //    return baseParam.Reaction + paramCorrect.Reaction;
    //}
    //public int getMobility()
    //{
    //    return baseParam.Mobility + paramCorrect.Mobility;
    //}

    //public int getFumble()
    //{
    //    return baseParam.Fumble + paramCorrect.Fumble;
    //}
}
