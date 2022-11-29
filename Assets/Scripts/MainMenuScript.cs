using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void start()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
