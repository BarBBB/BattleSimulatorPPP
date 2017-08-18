using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public static class GetWeb {
    const string BASE_URL = "https://p3p000603.herokuapp.com/rev1.reversion.jp/character/detail/";

    const string HEAD_REGEX = "<th(?: width=\"\\d\\d%\")?>";

    const string TAIL_REGEX = "</th><td(?: width=\"\\d\\d%\")?>\\s*(\\d+)</td>";

    const string TITLE_REGEX = "<span class=\"title\">『(.*?)』</span><br>";

    const string HEAD_TITLE = "<span class=\"title\">『";

    const string TAIL_TITLE = "』</span><br>\\s*?(.*?)<br>";

    public static IEnumerator GetText(PcInputWindow window, string pcId)
    {
        string url = BASE_URL + pcId;
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);

        // リクエスト送信
        yield return request.Send();

        // 通信エラーチェック
        if (request.isError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                // UTF8文字列として取得する
                string text = request.downloadHandler.text;
                Debug.Log(text);
                setPcParameter(text, window);
            }
        }
    }

    private static void setPcParameter(string text, PcInputWindow window)
    {
        text = text.Replace("\n", "");
        Debug.Log(text);

        PcParameter pcParam = new PcParameter();

        pcParam.Title = getTitle(text);
        Debug.Log(getTitle(text));
        pcParam.PcName = getPcName(text, pcParam.Title);
        Debug.Log(getPcName(text, pcParam.Title));

        pcParam.MaxHP = Int32.Parse(getTargetParameter(text, "HP"));
        pcParam.MaxAP = Int32.Parse(getTargetParameter(text, "AP"));
        pcParam.PAttack = Int32.Parse(getTargetParameter(text, "物理攻撃力"));
        pcParam.MAttack = Int32.Parse(getTargetParameter(text, "神秘攻撃力"));
        pcParam.Exf = Int32.Parse(getTargetParameter(text, "EXF"));
        pcParam.Defense = Int32.Parse(getTargetParameter(text, "防御技術"));
        pcParam.Resist = Int32.Parse(getTargetParameter(text, "特殊抵抗"));
        pcParam.Exa = Int32.Parse(getTargetParameter(text, "EXA"));
        pcParam.Hits = Int32.Parse(getTargetParameter(text, "命中"));
        pcParam.Avoid = Int32.Parse(getTargetParameter(text, "回避"));
        pcParam.Critical = Int32.Parse(getTargetParameter(text, "クリティカル"));
        pcParam.Reaction = Int32.Parse(getTargetParameter(text, "反応"));
        pcParam.Mobility = Int32.Parse(getTargetParameter(text, "機動力"));
        pcParam.Fumble = Int32.Parse(getTargetParameter(text, "ファンブル"));

        
        window.setPcParameter(pcParam);
    }

    private static string getTargetParameter(string text, string targetStr)
    {
        string regStr = HEAD_REGEX + targetStr + TAIL_REGEX;
        //Debug.Log("regStr：" + regStr);
        var reg = new Regex(regStr);
        Match m = reg.Match(text);

        if (m.Success)
        {
            return m.Groups[1].Value;
        }
        else
        {
            return "";
        }
    }

    private static string getTitle(string text)
    {
        var reg = new Regex(TITLE_REGEX);
        Match m = reg.Match(text);

        if (m.Success)
        {
            return m.Groups[1].Value;
        }
        else
        {
            return "";
        }
    }

    private static string getPcName(string text, string title)
    {
        string regStr = HEAD_TITLE + title + TAIL_TITLE;
        //Debug.Log("regStr：" + regStr);
        var reg = new Regex(regStr);
        Match m = reg.Match(text);

        if (m.Success)
        {
            return m.Groups[1].Value;
        }
        else
        {
            return "";
        }
    }
}
