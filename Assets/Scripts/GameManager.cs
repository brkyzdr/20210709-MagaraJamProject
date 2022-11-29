using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Text timer;
    AudioSource audio;
    public float countTime = 155F;
    float say=0;
    void Start()
    {
        timer.text = countTime.ToString();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        countTime -= Time.deltaTime;
        if (countTime > 100)
        {
            timer.text = countTime.ToString().Substring(0, 3);
        }
        else if (countTime > 10)
        {
            timer.text = countTime.ToString().Substring(0,2);
        }
        else if (countTime > 0)
        {
            timer.text = countTime.ToString().Substring(0, 1);
        }

        if (countTime < 0.01)
        {
            SceneManager.LoadScene("DeathScene");
        }
        if (countTime < 8 &&say!=1)
        {
            say = 1;
            audio.Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenuScript mms = new MainMenuScript();
            mms.ReturnMainMenu();
        }
    }
}
