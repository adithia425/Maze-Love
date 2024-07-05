using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPortal : MonoBehaviour
{
    public Transform positionSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            ObjectPlayer player = GameManager.instance.objectPlayer;
            player.transform.position = positionSpawn.position;

            player.rB.velocity = Vector3.zero;
            player.rB.angularVelocity = 0;
        }
    }
}
