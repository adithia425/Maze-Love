using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoading : MonoBehaviour
{
    public Animator anim;
    public bool isFirstShow;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        if (!isFirstShow) return;
        HideLoading();
        Invoke("HidePanelLoading", 1.1f);
    }
    public void HidePanelLoading()
    {
        gameObject.SetActive(false);
    }

    public void ShowLoading()
    {
        anim.SetBool("Open", true);
        anim.SetBool("Close", false);
    }
    public void HideLoading()
    {
        anim.SetBool("Close", true);
        anim.SetBool("Open", false);
    }
}
