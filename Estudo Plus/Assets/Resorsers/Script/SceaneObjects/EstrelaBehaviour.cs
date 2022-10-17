using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrelaBehaviour : MonoBehaviour
{
    private BeMasterMaximus beMMinstance;

    private void Awake()
    {
        beMMinstance = GameObject.FindGameObjectWithTag("MasterMaximus").GetComponent<BeMasterMaximus>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            beMMinstance.StarNumber += 1;
            beMMinstance.soundScript.PlayStarCollect();
            Destroy(this.gameObject);
        }
    }
}
