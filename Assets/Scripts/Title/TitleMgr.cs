using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMgr : MonoBehaviour {

    const string MASTER_DECOY = "p3p000603";

    public PcInputWindow pcWin1;
    public PcInputWindow pcWin2;

    // Use this for initialization
    void Start () {
        Debug.Log(this);

        StartCoroutine(setParameter());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator setParameter()
    {
        yield return new WaitForSeconds(0.1f);

        if (PcParamList.Instance.pcs.Count >= 2)
        {
            pcWin1.setPcParameter(PcParamList.Instance.pcs[0]);
            pcWin1.setPcIcon(PcParamList.Instance.pcs[0].Icon.texture);
            pcWin2.setPcParameter(PcParamList.Instance.pcs[1]);
            pcWin2.setPcIcon(PcParamList.Instance.pcs[0].Icon.texture);
        }
        else if (PcParamList.Instance.pcs.Count == 1)
        {
            pcWin1.setPcParameter(PcParamList.Instance.pcs[0]);
            pcWin1.setPcIcon(PcParamList.Instance.pcs[0].Icon.texture);
            StartCoroutine(GetWeb.GetText(pcWin2,MASTER_DECOY));
            //StartCoroutine(GetWeb.GetIcon(pcWin2, MASTER_DECOY));
        }
        else
        {
            StartCoroutine(GetWeb.GetText(pcWin2, MASTER_DECOY));
            //StartCoroutine(GetWeb.GetIcon(pcWin2, MASTER_DECOY));
        }
    }
}
