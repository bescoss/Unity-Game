using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text Score_text;
    public void Setup (int score)
    {
        gameObject.SetActive (true);
        Score_text.text = score.ToString () + " meters";
    }

    public void RestartScene()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
