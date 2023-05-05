using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused = false;


    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Debug.Log("1");
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                _isPaused = false;
                ResumeGame();
            }
            else if(!_isPaused)
            {
                Debug.Log("2");
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                _isPaused = true;
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0f;
    }
    
    private void ResumeGame()
    {
        AudioListener.volume = 1;
        Time.timeScale = 1f;
    }
}
