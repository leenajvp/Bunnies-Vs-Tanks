using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    public void NextLevelReached()
    {
        Scene scene = SceneManager.GetActiveScene();
        int currentLevel = scene.buildIndex;
        currentLevel++;
        PlayerPrefs.SetInt("Level", currentLevel);
        SceneManager.LoadScene(currentLevel);
    }
}
