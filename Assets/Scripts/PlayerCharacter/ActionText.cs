using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionText : MonoBehaviour {

    public List<PcAction> ActionList = new List<PcAction>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string actionText = "";

        foreach (PcAction action in ActionList)
        {
            if (actionText == "")
            {
                actionText = action.getName();
            }
            else
            {
                actionText += "," + action.getName();
            }
        }

        this.GetComponent<Text>().text = "宣言：" + actionText;
    }

    public int getPAttack()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.PAttack;
        }

        return value;
    }
    public int getMAttack()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.MAttack;
        }

        return value;
    }
    public int getExf()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Exf;
        }

        return value;
    }
    public int getDefense()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Defense;
        }

        return value;
    }
    public int getResist()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Resist;
        }

        return value;
    }
    public int getExa()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Exa;
        }

        return value;
    }
    public int getHits()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Hits;
        }

        return value;
    }
    public int getAvoid()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Avoid;
        }

        return value;
    }
    public int getCritical()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Critical;
        }

        return value;
    }
    public int getReaction()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Reaction;
        }

        return value;
    }
    public int getMobility()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Mobility;
        }

        return value;
    }

    public int getFumble()
    {
        int value = 0;
        foreach (PcAction action in ActionList)
        {
            value += action.Param.Fumble;
        }

        return value;
    }
}
