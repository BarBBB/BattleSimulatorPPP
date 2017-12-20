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

    public int getPAttack()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.PAttack;
        }

        return value;
    }
    public int getMAttack()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.MAttack;
        }

        return value;
    }
    public int getExf()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Exf;
        }

        return value;
    }
    public int getDefense()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Defense;
        }

        return value;
    }
    public int getResist()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Resist;
        }

        return value;
    }
    public int getExa()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Exa;
        }

        return value;
    }
    public int getHits()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Hits;
        }

        return value;
    }
    public int getAvoid()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Avoid;
        }

        return value;
    }
    public int getCritical()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Critical;
        }

        return value;
    }
    public int getReaction()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Reaction;
        }

        return value;
    }
    public int getMobility()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Mobility;
        }

        return value;
    }

    public int getFumble()
    {
        int value = 0;
        foreach (BadStatus bs in BsList)
        {
            value += bs.Param.Fumble;
        }

        return value;
    }
}
