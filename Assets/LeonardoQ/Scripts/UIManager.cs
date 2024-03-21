using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject panelPause;
    public GameObject panelWin;
    public GameObject panelLose;
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
    }

    public void ActivatePanelPause()
    {
        panelPause.SetActive(true);
    }

    public void DeactivatePanelPause()
    {
        panelPause.SetActive(false);
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



}
