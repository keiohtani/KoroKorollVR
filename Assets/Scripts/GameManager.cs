using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject panelGM;

	public void PlayGame()
    {
        panelGM.SetActive(false);
    }

	public static void ResetGame()
	{
        SceneManager.LoadScene("Main");
	}
}
