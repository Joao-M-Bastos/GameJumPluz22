using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeMasterMaximus : MonoBehaviour
{

    private bool hasTakenDamage;

    private float starNumber;

    private void OnLevelWasLoaded(int i)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (hasTakenDamage) Debug.Log("Se fudeu");
    }

    public bool HasTakenDamage
    {
        get { return HasTakenDamage; }
        set { hasTakenDamage = value; }
    }

    public float StarNumber
    {
        get { return starNumber; }
        set { starNumber = value; }
    }
}
