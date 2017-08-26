using UnityEngine;
using System.Collections;
 using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System;

public class WebGetButton : MonoBehaviour
{
    public InputManager PcId;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        Debug.Log(this);
        PcInputWindow window = transform.parent.parent.parent.GetComponent<PcInputWindow>();
        StartCoroutine(GetWeb.GetText(window, PcId.inputField.text));
        StartCoroutine(GetWeb.GetIcon(window, PcId.inputField.text));
    }
}
