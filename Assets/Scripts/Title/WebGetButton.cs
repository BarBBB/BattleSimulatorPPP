using UnityEngine;
using System.Collections;
 using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System;

public class WebGetButton : MonoBehaviour
{
    private InputManager PcId;

    private PcInputWindow window;

    // Use this for initialization
    void Start()
    {
        PcId = transform.parent.Find("WebGetInputField").GetComponent<InputManager>();
        window = transform.parent.parent.parent.GetComponent<PcInputWindow>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (window.getIconURL() != null) {
            StartCoroutine(GetWeb.GetIcon(window, window.getIconURL()));
            window.setIconURL(null);
        }
    }

    public void OnClick()
    {
        Debug.Log(this);
        StartCoroutine(GetWeb.GetText(window, PcId.getInputField(), false));
    }
}
