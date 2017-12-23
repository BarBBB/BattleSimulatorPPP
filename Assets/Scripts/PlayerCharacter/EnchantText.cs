using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantText : MonoBehaviour {

    public List<EnchantSkill> EnchantList = new List<EnchantSkill>();

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        string enchantText = "";

        foreach (EnchantSkill enchant in EnchantList)
        {
            int count = EnchantSkill.END_TURN_COUNT - enchant.getCount() + 1;
            string bsStr = enchant.getName() + "(" + count + ")";
            if (enchantText == "")
            {
                enchantText = bsStr;
            }
            else
            {
                enchantText += "," + bsStr;
            }
        }

        this.GetComponent<Text>().text = "付与：" + enchantText;
    }

    public int getPAttack()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.PAttack;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getMAttack()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.MAttack;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getExf()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Exf;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getDefense()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Defense;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getResist()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Resist;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getExa()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Exa;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getHits()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Hits;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getAvoid()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Avoid;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getCritical()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Critical;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getReaction()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Reaction;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
    public int getMobility()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Mobility;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }

    public int getFumble()
    {
        int selfPvalue = 0;
        int selfMvalue = 0;
        int otherPvalue = 0;
        int otherMvalue = 0;
        foreach (EnchantSkill es in EnchantList)
        {
            int value = es.Param.Fumble;
            if (value > 0)
            {
                if (es.IsOther)
                {
                    if (otherPvalue < value)
                    {
                        otherPvalue = value;
                    }
                }
                else
                {
                    if (selfPvalue < value)
                    {
                        selfPvalue = value;
                    }
                }
            }
            else
            {
                if (es.IsOther)
                {
                    otherMvalue += value;
                }
                else
                {
                    selfMvalue += value;
                }
            }
        }

        return selfPvalue + selfMvalue + otherPvalue + otherMvalue;
    }
}
