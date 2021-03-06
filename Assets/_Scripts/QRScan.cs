﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QRScan : MonoBehaviour {
	
	public QRCodeDecodeController e_qrController;
	string dataText;

	void Start () {
		e_qrController.onQRScanFinished += GetResult;
	}

	void GetResult(string result) {
		dataText = result;
		init.iid = dataText;
		GotoNextScene ("8_Item");
	}

	public void Load_Exhibition()
	{
		GotoNextScene ("5_Exhibition");
	}

	public void GotoNextScene(string scenename)
	{
		if (e_qrController != null) {
			e_qrController.StopWork();
		}
		SceneManager.LoadScene(scenename);
	}
}
