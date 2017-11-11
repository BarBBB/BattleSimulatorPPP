using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullAttackButton : MonoBehaviour {

    protected BattleEngine battleEngine;

    public Text text;

    private bool flg = false;

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.Find("BattleEngine");
        battleEngine = go.GetComponent<BattleEngine>();
    }

    public void OnClick()
    {
        battleEngine.flipFullAttackFlg();
        if (flg)
        {
            text.text = ActionManage.FULL_ATTACK;
            flg = false;
        }
        else
        {
            text.text = ActionManage.FULL_ATTACK + ":ON";
            flg = true;
        }
    }

    public void init()
    {
        text.text = ActionManage.FULL_ATTACK;
        flg = false;
    }
}
