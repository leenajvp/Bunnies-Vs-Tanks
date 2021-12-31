using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompl : MonoBehaviour
{
    public int LevelReached;

    void Start()
    {

    }

    public void Continue()
    {
        Debug.Log(PlayerPrefs.GetInt("Level"));
        int level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
