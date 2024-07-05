using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    public GameObject effectDestroy;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEffect(EffectSpawned eff, Transform pos)
    {
        GameObject oSpawn = null;

        switch (eff)
        {
            case EffectSpawned.EFFECT_DESTROY:
                oSpawn = effectDestroy;
                break;
        }

        if(oSpawn != null)
            Instantiate(oSpawn, pos.position, Quaternion.identity);
    }
}

public enum EffectSpawned{
    EFFECT_DESTROY
}
