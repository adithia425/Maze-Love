using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public PanelLoading panelLoading;
    [SerializeField]
    private float timeLoading;
    private string nameScene;
    public void ChangeScene(string name)
    {
        nameScene = name;
        panelLoading.gameObject.SetActive(true);
        panelLoading.ShowLoading();

        Invoke("SceneChanged", timeLoading);
    }

    private void SceneChanged()
    {
        SceneManager.LoadScene(nameScene);
    }

    public void ExitGame()
    {
        panelLoading.gameObject.SetActive(true);
        panelLoading.ShowLoading();
        Invoke("Exit", 1.25f);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
