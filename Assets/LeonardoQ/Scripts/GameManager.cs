using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    [SerializeField] bool isPaused, win, lose;
    

    // Start is called before the first frame update
    void Start()
    {
        StarGame();
        CursorControl();
    }

    // Update is called once per frame
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
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void PanelPause()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Cancel") && isPaused)
        {
            ResumeGame();
        }
    }

    private void Win()
    {
        if(win)
        {
            uiManager.ActivatePanelWin();
        }
    }

    private void Lose()
    {
        if (lose)
        {
            uiManager.ActivatePanelLose();
        }
    }

    public void PauseGame()
    {
        uiManager.ActivatePanelPause();
        Time.timeScale = 0;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResumeGame()
    {
        uiManager.DeactivatePanelPause();
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

}
