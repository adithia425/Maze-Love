using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectKey : MonoBehaviour
{
    public UnityEvent activatedKey;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            SoundManager.instance.PlaySFX(SFX.GETITEM);
            activatedKey.Invoke();
            EffectManager.instance.SpawnEffect(EffectSpawned.EFFECT_DESTROY, transform);
            Destroy(gameObject);
        }
    }
}
