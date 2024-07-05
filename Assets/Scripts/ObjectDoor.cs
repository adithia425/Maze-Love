using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDoor : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void OpenTheDoor()
    {
        anim.SetTrigger("Play");
    }
}
