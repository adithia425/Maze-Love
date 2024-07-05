using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject panelGoal;
    public GameObject panelDie;
    public PanelLoading panelLoading;


    public TextMeshProUGUI textPower;

    public Button buttonFood;
    public GameObject panelBigger;
    public TextMeshProUGUI textBigger;


    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textEnding;
    private void Awake()
    {
        instance = this;
    }


    public void SetPanelGoal(bool con)
    {
        panelGoal.SetActive(con);

    }
    public void SetPanelDie(bool con)
    {
        panelDie.SetActive(con);
    }
    public void SetPanelBigger(bool con)
    {
        panelBigger.SetActive(con);
    }
    public void SetPanelLoading(bool con)
    {
        panelLoading.gameObject.SetActive(con);
    }
    public void GameWin(int time)
    {
        string txt = "Tamat\nKamu Menemukan Cintamu\nDalam Waktu : " + time;
        textEnding.text = txt;
    }

    public void SetTimer(int timer)
    {
        textTimer.text = "Waktu: " + timer.ToString();
    }

 
    void Start()
    {
        SetPanelLoading(true);
    }

    void Update()
    {

        float power = GameManager.instance.GetPowerMap();
        if (power > 0)
            textPower.text = power.ToString("#.00");
        else
            textPower.text = "0";
    }

    public void SetInfoBigger(float counter)
    {
        if(counter > 0)
        {
            textBigger.text = counter.ToString("#.00");
        }
        else
        {
            panelBigger.SetActive(false);
        }
    }

    public void SetButtonFood(bool con)
    {
        if(con)
        {
            buttonFood.interactable = true;
        }
        else
        {
            buttonFood.interactable = false;
        }
    }
}
