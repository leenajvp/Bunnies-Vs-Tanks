using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalData : MonoBehaviour
{
    public GameObject PLayer;
    public GameObject pauseMenu;

    static public bool paused = false;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseMenu();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseMenu()
    {
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        PLayer.GetComponent<PlayerMovement>().enabled = false;
    }

    public void UnPause()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        PLayer.GetComponent<PlayerMovement>().enabled = true;
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level4");
        Time.timeScale = 1f;
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level5");
        Time.timeScale = 1f;
    }
}
