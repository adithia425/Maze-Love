using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlayer : MonoBehaviour
{
    public Rigidbody2D rB;

    public GameObject[] listObjectFace;
    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SetFace(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFace(int idx)
    {
        for (int i = 0; i < listObjectFace.Length; i++)
        {
            if(i == idx)
                listObjectFace[i].SetActive(true);
            
            else
                listObjectFace[i].SetActive(false);
        }
    }

    public void SetBigger()
    {
        transform.localScale = new Vector3(1.8f, 1.8f, 1);
        SetFace(1);
    }

    public void SetNormal()
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 1);
        SetFace(0);
    }

    public void Die()
    {
        SetFace(2);
    }
}
