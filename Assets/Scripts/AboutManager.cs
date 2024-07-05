using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutManager : MonoBehaviour
{
    public Animator animMain;
    public Animator animAbout;
    void Start()
    {
        animMain.SetBool("IsShow", true);
    }

    public void ButtonAbout()
    {
        animMain.SetBool("IsShow", false);
        animAbout.gameObject.SetActive(true);
        animAbout.SetBool("IsShow", true);
        Invoke("AboutHide", 3f);
    }

    public void AboutHide()
    {
        animMain.SetBool("IsShow", true);
        animAbout.SetBool("IsShow", false);
    }

}
