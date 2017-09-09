using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        // ログメッセージをクリア
        ManageScroll.Logs = "";
        //Titleシーン遷移
        SceneManager.LoadScene("Battle");
    }
}
