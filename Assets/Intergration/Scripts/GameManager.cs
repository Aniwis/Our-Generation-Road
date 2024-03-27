using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    
    public bool isPaused, win, lose;
    public int playerOnScene;


    
    void Start()
    {
        StarGame();
        CursorControl();
    }

    
    void Update()
    {
        PanelPause();
        Win();
        Lose();
    }

    private void StarGame()
    {
        isPaused = false;
        win = false;
        lose = false;
        playerOnScene = 0;
    }

    private void PanelPause()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            PauseGame();
            isPaused = true;
        }
        else if (Input.GetButtonDown("Cancel") && isPaused)
        {
            ResumeGame();
            isPaused = false;
        }
    }

    private void Win()
    {
        if(win)
        {
            UIManager.Instance.ActivatePanelWin();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Lose()
    {
        if (lose)
        {
            UIManager.Instance.ActivatePanelLose();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PauseGame()
    {
        UIManager.Instance.ActivatePanelPause();
        Time.timeScale = 0;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResumeGame()
    {
        UIManager.Instance.DeactivatePanelPause();
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void CursorControl()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CursorControlActive()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //musica que suena dependiendo de en cual escena esté el player
    //public void PlayMusicScena()
    //{
    //    if(playerOnScene == 1)
    //    {
    //        AudioManager.Instance.PlayMusic(1);

    //    }else if(playerOnScene == 2)
    //    {
    //        AudioManager.Instance.PlayMusic(2);
    //    }else if(playerOnScene == 3)
    //    {
    //        AudioManager.Instance.PlayMusic(3);
    //    }
    //}

    public void Mute()
    {
        UIManager.Instance.musicVolSlider.value = -80;
    }
    public void Unmute()
    {
        UIManager.Instance.musicVolSlider.value = 0;
    }

}
