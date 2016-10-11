using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour {
    public void Load_Home() {
        SceneManager.LoadScene("1_Home");
    }

    public void Load_Select_Member() {
        SceneManager.LoadScene("2_Select_Member");
    }

    public void Load_Member_Description() {
        SceneManager.LoadScene("3_Member");
    }

    public void Load_Select_Exhibition() {
        SceneManager.LoadScene("4_Select_Exhibition");
    }

	public void Load_Exhibition()
	{
		SceneManager.LoadScene("5_Exhibition");
	}

	public void Load_QRScan() {
		SceneManager.LoadScene("6_QRScan");
	}

	public void Load_Treasure() {
		SceneManager.LoadScene("7_Treasure");
	}

	public void Load_Item() {
		SceneManager.LoadScene("8_Item");
	}
}
