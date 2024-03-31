using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    public GameObject panelPause, panelAudio, panelWin, panelLose;
    public Button buttonPanelAudio;
    public Slider musicVolSlider, sfxVolSlider;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        panelPause = GetComponentInChildren<Canvas>().transform.Find("PanelPause").gameObject;
        panelPause.gameObject.SetActive(false);
        panelWin = GetComponentInChildren<Canvas>().transform.Find("PanelWin").gameObject;
        panelWin.gameObject.SetActive(false);
        panelLose = GetComponentInChildren<Canvas>().transform.Find("PanelLose").gameObject;
        panelLose.gameObject.SetActive(false);
        panelAudio = GetComponentInChildren<Canvas>().transform.Find("PanelAudio").gameObject;
        panelAudio.gameObject.SetActive(false);
        buttonPanelAudio.onClick.AddListener(ActivatePanelAudio);

    }

    public void ActivatePanelPause()
    {
        panelPause.SetActive(true);
    }

    public void DeactivatePanelPause()
    {
        panelPause.SetActive(false);
        panelAudio.SetActive(false);
    }

    public void ActivatePanelWin()
    {
        panelWin.SetActive(true);
    }
    public void DesactivatePanelWin()
    {
        panelWin.SetActive(false);
    }
    public void ActivatePanelLose()
    {
        panelLose.SetActive(true);
    }
    public void DesactivatePanelLose()
    {
        panelLose.SetActive(false);
    }
    public void ActivatePanelAudio()
    {
        panelAudio.SetActive(true);
    }

    public void SetMusicLevel()
    {
        AudioManager.Instance.SetMusicLevel();
    }
    public void SetSFXLevel()
    {

        AudioManager.Instance.SetSFXLevel();
    }

    
  
}