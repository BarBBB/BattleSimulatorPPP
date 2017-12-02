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

    const string HEAD_NAME = "<span class=\"title\">『";

    const string TAIL_NAME = "』</span><br>\\s*?(.*?)<br>";

    const string DEFAULT_ICON = "https://rev1.reversion.jp/assets/images/default/icon.png";

    const string PC_ICON_HEAD = "(https://img.rev1.reversion.jp/illust/";

    const string PC_ICON_MIDDLE = "/icon/.+?jpg)";

    const string PROXY_HEADER = "https://p3p000603.herokuapp.com/";

    const string HTTPS_HEADER = "https://";

    const string CLASS_REGEX = "<a href= #class_flavor class=\"fancybox\">(.*?)</a>";

    const string ESPRIT_REGEX = "<a href= #esprit_flavor class=\"fancybox\">(.*?)</a>";

    const string SKILL_NAME_REGEX = "<a href= #skill_flavor\\d+ class=\"fancybox\">(.*?)</a>";

    const string SKILL_ETC_REGEX = "<td nowrap=\"nowrap\">.*?</td>.*?<td>(.*?)</td>";

    const string SKILL_REGEX = "<tr class=\"eq_kind01\">.*?<div class=\"con_hide\" id= skill_flavor[12]\\d*>.*?</div>.*?<td>.*?"
            + "<abbr class=\"tooltip_fa\" title=\"\" rel=\"tooltip\">.*?<a href= #skill_flavor\\d+ class=\"fancybox\">(.*?)</a>.*?"
            + "<td nowrap=\"nowrap\">.*?</td>.*?<td>(.*?)</td>";


    private static void getSkill(PcParameter pcParam, string text)
    {
        string regStr = SKILL_REGEX;
        Debug.Log("regStr：" + regStr);
        var reg = new Regex(regStr);

        Match m = reg.Match(text);
        if (m.Success)
        {
            pcParam.Skill1 = new Skill();
            pcParam.Skill1.Name = m.Groups[1].Value;
            pcParam.Skill1.Etc = m.Groups[2].Value;
        }
        else
        {
            return;
        }

        m = m.NextMatch();
        if (m.Success)
        {
            pcParam.Skill2 = new Skill();
            pcParam.Skill2.Name = m.Groups[1].Value;
            pcParam.Skill2.Etc = m.Groups[2].Value;
        }
        else
        {
            return;
        }

        m = m.NextMatch();
        if (m.Success)
        {
            pcParam.Skill3 = new Skill();
            pcParam.Skill3.Name = m.Groups[1].Value;
            pcParam.Skill3.Etc = m.Groups[2].Value;
        }
        else
        {
            return;
        }

        m = m.NextMatch();
        if (m.Success)
        {
            pcParam.Skill4 = new Skill();
            pcParam.Skill4.Name = m.Groups[1].Value;
            pcParam.Skill4.Etc = m.Groups[2].Value;
        }
        else
        {
            return;
        }
    }

    public static IEnumerator GetText(PcInputWindow window, string pcId)
    {
        string url = BASE_URL + pcId;
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);

        // リクエスト送信
        yield return request.Send();

        // 通信エラーチェック
        if (request.isNetworkError)
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
                setPcParameter(text, window, pcId);
            }
        }
    }

    public static IEnumerator GetIcon(PcInputWindow window, string url)
    {
        url = url.Replace(HTTPS_HEADER, PROXY_HEADER);
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        // リクエスト送信
        yield return request.Send();

        // 通信エラーチェック
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // DownloadHandlerを継承したDownloadHandlerTexture経由で取得できる
            window.setPcIcon(((DownloadHandlerTexture)request.downloadHandler).texture);
        }
    }

    private static void setPcParameter(string text, PcInputWindow window, string pcId)
    {
        text = text.Replace("\n", "");
        Debug.Log(text);

        PcParameter pcParam = new PcParameter();

        pcParam.Title = getTitle(text);
        pcParam.PcName = getPcName(text, pcParam.Title);

        pcParam.PcClass = getPcClass(text);
        pcParam.Esprit = getEsprit(text);

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

        getSkill(pcParam, text);

        window.setPcParameter(pcParam);

        string url = getIconUrl(text, pcId);
        Debug.Log("url：" + url);
        window.setIconURL(url);

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

    private static string getPcClass(string text)
    {
        var reg = new Regex(CLASS_REGEX);
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

    private static string getEsprit(string text)
    {
        var reg = new Regex(ESPRIT_REGEX);
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
        string regStr = HEAD_NAME + title + TAIL_NAME;
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

    private static string getIconUrl(string text, string pcId)
    {
        string regStr = PC_ICON_HEAD + pcId + PC_ICON_MIDDLE;
        Debug.Log("regStr：" + regStr);
        var reg = new Regex(regStr);
        Match m = reg.Match(text);

        if (m.Success)
        {
            return m.Groups[1].Value;
        }
        else
        {
            return DEFAULT_ICON;
        }
    }

}
