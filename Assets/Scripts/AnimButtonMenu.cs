using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimButtonMenu : MonoBehaviour
{
    public RectTransform trans;
    public bool isHover;

    float counter;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float startPos;

    [SerializeField]
    private float endPos;

    private void Awake()
    {
        trans = GetComponent<RectTransform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = trans.position;
        if (isHover)
        {
            if(pos.x < endPos)
            {
                pos.x += speed * Time.deltaTime;
            }
        }
        else
        {
            if (pos.x > startPos)
            {
                pos.x -= speed * Time.deltaTime;
            }
        }

        trans.position = new Vector3(pos.x, pos.y, pos.z);
    }
    public void IsHover(bool con)
    {
        isHover = con;
    }
}
