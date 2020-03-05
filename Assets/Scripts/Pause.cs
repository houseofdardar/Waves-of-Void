using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    bool mouseVisible;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
               // Cursor.visible = true;
                
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
                //Cursor.visible = false;
                
            }
        }

        if (mouseVisible)
            Cursor.visible = true;
        else
            Cursor.visible = false;


    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
        Cursor.lockState = CursorLockMode.None;
        mouseVisible = true;
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
        Cursor.lockState = CursorLockMode.Locked;
        mouseVisible = false;
    }
    public void PauseButton()
    {
         ContinueGame();
    }
}
