using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFood : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.instance.ClaimFood();
            SoundManager.instance.PlaySFX(SFX.GETITEM);
            Destroy(gameObject);
        }
    }
}
