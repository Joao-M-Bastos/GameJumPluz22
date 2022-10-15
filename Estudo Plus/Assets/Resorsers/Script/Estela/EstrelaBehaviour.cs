using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrela : MonoBehaviour
{
    [SerializeField] private BeMasterMaximus MMinstance;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            MMinstance.StarNumber += 1;
            Destroy(this.gameObject);
        }
    }
}
