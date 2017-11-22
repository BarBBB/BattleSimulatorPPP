using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour {

    private PcInputWindow window;

    // Use this for initialization
    void Start () {
        Debug.Log(this);
        window = transform.parent.parent.GetComponent<PcInputWindow>();
    }

    public void OnClick()
    {
        window.init();
    }
}
