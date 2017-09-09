using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ActionButton : MonoBehaviour
{
    protected BattleEngine battleEngine;

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.Find("BattleEngine");
        battleEngine = go.GetComponent<BattleEngine>();
    }

    public void OnClick()
    {
        battleEngine.buttonClickAction(getText());
    }


    /// テキストを取得する
    private string getText()
    {

        foreach (Transform child in transform)
        {
            // 子要素をたどる
            if (child.name == "Text")
            {
                // テキストを見つけた
                Text t = child.GetComponent<Text>();
                // テキスト変更
                return t.text;
            }
        }

        return "";
    }

}