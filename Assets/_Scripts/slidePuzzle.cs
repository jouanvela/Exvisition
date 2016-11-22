using UnityEngine;
using System.Collections;

public class slidePuzzle : MonoBehaviour 
{
	public GameObject finishBtn;

	// 拼圖的完成位置
	private byte[] CompleteLocation;
	// 拼圖的目前位置
	private byte[] CurLocation;
	// 拼圖是否完成
	private bool Complete;
	// 滑鼠點擊射線
	Ray ray;
	RaycastHit hit;

	// alpha 從0到1的所需時間
	public float Duration;
	// alpha 變動值
	private float alpha;
	// Renderer
	private Renderer rend;
	// Renderer.Material.Color
	private Color MColor;

	//check if img ready
	private int count = 0;

	IEnumerator Start () 
	{
		Complete = false;
		CompleteLocation = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
		byte[] tmpLocation = new byte[] {1, 2, 3, 4, 5, 6, 8, 7};
		CurLocation = new byte[9];

		//pic
		string url;
		for (int i = 0; i < 9; i++){
			url = (init.mode + "/item/" + init.iid + "/puzzle_"+ i +".png");
			//url = (init.mode + "/item/" + init.iid + "/picture.jpg");
			StartCoroutine(LoadPic(url,i));
		}

		while (count < 9)
			yield return new WaitForSeconds (0.1f);

		//迴圈從後往前
		for (int i = tmpLocation.Length - 1; i >= 0 ; i--){
			// 決定隨機數 範圍由大變小 避免重複
			int random = Random.Range(0, i);

			// 第 i 個 數字與隨機數交換
			byte tmp = tmpLocation[random];
			tmpLocation[random] = tmpLocation[i];
			tmpLocation[i] = tmp;

			CurLocation[i] = tmpLocation[i];
		}

		// 陣列最後面補上9
		CurLocation.SetValue((byte)9, 8);


		//把物件位置更新成打亂的位置
		for (int i = 0; i < CurLocation.Length; i++){
			transform.GetChild(CurLocation[i] - 1).GetChild(0).parent = transform.GetChild(i).transform;
			transform.GetChild(i).GetChild((transform.GetChild(i).childCount) - 1).localPosition = Vector3.zero;
		}

		// 把 9 的透明度降為 0
		rend = transform.GetChild(8).GetChild(0).GetComponent<Renderer>();
		MColor = rend.material.GetColor("_Color");
		MColor.a = 0;
		rend.material.SetColor ("_Color", MColor);
	}

	IEnumerator LoadPic(string url, int i){
		WWW www;
		www = new WWW(url);
		yield return www;
		Debug.Log (url);
		Texture2D text = www.texture as Texture2D;
		transform.GetChild(i).GetChild(0).GetComponent<Renderer>().material.mainTexture = text;
		count++;
	}

	void Update (){
		// 如果拼圖未完成才進行
		if (!Complete){
			//9(空格)的index
			byte tmpindex = 0;
			//取得空格的位置
			for (int i = 0; i < CurLocation.Length; i++){
				if (CurLocation [i] == 9)
					tmpindex = (byte)i;
			}
			/// 
			/// 用鍵盤控制拼圖
			///
			//按下方向鍵之後 判斷空格的位置，交換相對應物件的位置跟陣列值
			if (Input.GetKeyDown (KeyCode.W)){
				// 如果空格在1 2 3 4 5 6 可以往上，
				// 把空格(tmpindex)跟4 5 6 7 8 9(tmpindex+3)的位置跟陣列值交換。
				switch (tmpindex){
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						MovePuzzle (tmpindex, 3);
						break;
				}
			} 
			else if (Input.GetKeyDown (KeyCode.S)){
				// 如果空格在4 5 6 7 8 9 可以往下，
				// 把空格(tmpindex)跟1 2 3 4 5 6(tmpindex-3)的位置跟陣列值交換。
				switch (tmpindex){
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
						MovePuzzle (tmpindex, -3);
						break;
				}
			} 
			else if (Input.GetKeyDown (KeyCode.A)){
				// 如果空格在1 4 7 2 5 8 可以往左，
				// 把空格(tmpindex)跟2 5 8 3 6 9(tmpindex+1)的位置跟陣列值交換。
				switch (tmpindex){
					case 0:
					case 3:
					case 6:
					case 1:
					case 4:
					case 7:
						MovePuzzle (tmpindex, 1);
						break;
				}
			} 
			else if (Input.GetKeyDown (KeyCode.D)){
				// 如果空格在2 5 8 3 6 9 可以往右，
				// 把空格(tmpindex)跟1 4 7 2 5 8 (tmpindex-1)的位置跟陣列值交換。
				switch (tmpindex){
					case 1:
					case 4:
					case 7:
					case 2:
					case 5:
					case 8:
						MovePuzzle (tmpindex, -1);
						break;
				}
			}

			/// 
			/// 用滑鼠控制拼圖
			///
			//如果按下滑鼠左鍵
			if (Input.GetMouseButtonDown(0)){
				// 將螢幕座標轉換成射線
				ray = Camera.main.ScreenPointToRay( Input.mousePosition);
				if(Physics.Raycast(ray,out hit,100)){
					// 如果射中拼圖
					if (hit.transform.tag == "Puzzle"){	
						//被射中的拼圖名稱
						switch (hit.transform.parent.name){
							case "1":
								if (tmpindex == 1)
									MovePuzzle (tmpindex, -1);
								else if (tmpindex == 3)
									MovePuzzle (tmpindex, -3);
								break;
							case "2":
								if (tmpindex == 0)
									MovePuzzle (tmpindex, 1);
								else if (tmpindex == 2)
									MovePuzzle (tmpindex, -1);
								else if (tmpindex == 4)
									MovePuzzle (tmpindex, -3);
								break;
							case "3":
								if (tmpindex == 1)
									MovePuzzle (tmpindex, 1);
								else if (tmpindex == 5)
									MovePuzzle (tmpindex, -3);
								break;
							case "4":
								if (tmpindex == 0)
									MovePuzzle (tmpindex, 3);
								else if (tmpindex == 4)
									MovePuzzle (tmpindex, -1);
								else if (tmpindex == 6)
									MovePuzzle (tmpindex, -3);
								break;
							case "5":
								if (tmpindex == 1)
									MovePuzzle (tmpindex, 3);
								else if (tmpindex == 3)
									MovePuzzle (tmpindex, 1);
								else if (tmpindex == 5)
									MovePuzzle (tmpindex, -1);
								else if (tmpindex == 7)
									MovePuzzle (tmpindex, -3);
								break;
							case "6":
								if (tmpindex == 2)
									MovePuzzle (tmpindex, 3);
								else if (tmpindex == 4)
									MovePuzzle (tmpindex, 1);
								else if (tmpindex == 8)
									MovePuzzle (tmpindex, -3);
								break;
							case "7":
								if (tmpindex == 3)
									MovePuzzle (tmpindex, 3);
								else if (tmpindex == 7)
									MovePuzzle (tmpindex, -1);
								break;
							case "8":
								if (tmpindex == 4)
									MovePuzzle (tmpindex, 3);
								else if (tmpindex == 6)
									MovePuzzle (tmpindex, 1);
								else if (tmpindex == 8)
									MovePuzzle (tmpindex, -1);
								break;
							case "9":
								if (tmpindex == 5)
									MovePuzzle (tmpindex, 3);
								else if (tmpindex == 7)
									MovePuzzle (tmpindex, 1);
								break;
						}
					}
				}
			}

			//驗證拼圖是否完成
			byte tmpComplete = 0;
			for (int i = 0; i < CurLocation.Length; i++){
				//如果拼圖位置正確 數值累加
				if (CurLocation [i] == CompleteLocation [i])
					tmpComplete++;
			}
			//如果每塊拼圖位置都對 代表拼圖完成
			if (tmpComplete == 9) Complete = true;
		} 
		else{
			//計算alpha的浮動值 
			alpha += (1 / Duration) * Time.deltaTime;
			
			//更新 Alpha
			MColor.a = alpha;
			rend.material.SetColor ("_Color", MColor);
			finishBtn.SetActive(true);
		}
	}

	void MovePuzzle (int tmpindex, int MoveValue){
		// 空格 跟 對應物件 的位置交換，並把相對位置歸零
		transform.GetChild(tmpindex+MoveValue).GetChild(0).parent = transform.GetChild(tmpindex).transform;
		transform.GetChild(tmpindex).GetChild(0).parent = transform.GetChild(tmpindex+MoveValue).transform;
		transform.GetChild(tmpindex+MoveValue).GetChild(0).localPosition = Vector3.zero;
		transform.GetChild(tmpindex).GetChild(0).localPosition = Vector3.zero;
		// 空格 跟 對應物件 的陣列值交換
		byte tmp = 0;	//陣列暫存用
		tmp = CurLocation[tmpindex];
		CurLocation[tmpindex] = CurLocation[tmpindex+MoveValue];
		CurLocation[tmpindex+MoveValue] = tmp;
	}
}