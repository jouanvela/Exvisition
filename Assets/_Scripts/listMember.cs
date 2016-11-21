using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class listMember : MonoBehaviour {
    public GameObject copyGameObject;//要被複製的物件
    public GameObject superGameObject;//要被放置在哪個物件底下
    private GameObject[] childGameObject;//被複製出來的物件
	string[] members = init.membersList;

    void Start() {
		childGameObject = new GameObject[members.Length - 1];
        for (int i = 0; i < members.Length - 1; i++) {
			StartCoroutine (image(i));
        }
    }

	IEnumerator image(int i){
		childGameObject[i] = Instantiate(copyGameObject);//複製copyGameObject物件
		childGameObject[i].transform.SetParent(superGameObject.transform);//放到superGameObject物件內
		childGameObject[i].transform.localPosition = new Vector3(0, 200 - 250 * i, 0);//複製出來的物件放置的座標為superGameObject物件內的原點
		childGameObject[i].transform.localScale = Vector3.one;
		childGameObject[i].name = members[i]; //將複製出來的子物件重新命名

		string path = "file://" + Application.temporaryCachePath + "/member/" + members[i] + ".png";
		WWW www = new WWW(path);
		yield return www;
		Sprite s = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
		childGameObject[i].GetComponentsInChildren<Image>()[1].sprite = s;

		childGameObject[i].SetActive (true);
		Button btn = childGameObject[i].GetComponentsInChildren<Button>()[0];
		Click(btn, members[i]);
	}

    void Click(Button btn, string str){
        btn.onClick.AddListener(() => { init.mid = str; });
    }
}
	
