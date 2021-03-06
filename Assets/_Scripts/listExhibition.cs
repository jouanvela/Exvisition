﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class listExhibition : MonoBehaviour {
    public GameObject copyGameObject;//要被複製的物件
    public GameObject superGameObject;//要被放置在哪個物件底下
    private GameObject[] childGameObject;//被複製出來的物件

    IEnumerator Start() {

		string url = string.Concat(init.mode,"/listExhibition.php?mid=", init.mid);
		WWW www = new WWW(url);
        yield return www;

        string exhibitionList = www.text;
        string[] exhibitions = exhibitionList.Split(';');
        childGameObject = new GameObject[exhibitions.Length - 1];

		string[] temp;
        for (int i = 0; i < exhibitions.Length - 1; i++) {
			temp = exhibitions[i].Split(',');
            childGameObject[i] = Instantiate(copyGameObject);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
            childGameObject[i].transform.SetParent(superGameObject.transform);//放到superGameObject物件內
			childGameObject[i].transform.localPosition = new Vector3(-40.3865f, 300 - 250 * i, 0);//複製出來的物件放置的座標為superGameObject物件內的相對位置
            childGameObject[i].transform.localScale = Vector3.one;
            childGameObject[i].name = temp[0]; //將複製出來的子物件重新命名

            childGameObject[i].GetComponent<Image>().color = new Color(1, 1, 1, 255);
			childGameObject[i].GetComponentInChildren<Text>().text = temp[1];//更改顯示文字
            Button btn = childGameObject[i].GetComponent<Button>();
			Click(btn, temp[0]);
        }
        Destroy(copyGameObject);
    }

    void Click(Button btn, string str) {
        btn.onClick.AddListener(() => { init.eid = str; });
        //btn.onClick.AddListener(() => { Debug.Log(str); });
    }
}
