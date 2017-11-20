using UnityEngine;
using System.Collections;
 using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System;

public class WebGetButton : MonoBehaviour
{
    public InputManager PcId;

    public PcInputWindow window;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (window.IconURL != null) {
            StartCoroutine(GetWeb.GetIcon(window, window.IconURL));
            window.IconURL = null;
        }
    }

    public void OnClick()
    {
        Debug.Log(this);
        StartCoroutine(GetWeb.GetText(window, PcId.getInputField()));
    }
}
