using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private float starInNeed;
    
    private BeMasterMaximus beMMinstance;
    private Loader sceaneLoaderMM;

    private void Awake()
    {
        beMMinstance = GameObject.FindGameObjectWithTag("MasterMaximus").GetComponent<BeMasterMaximus>();
        sceaneLoaderMM = GameObject.FindGameObjectWithTag("MasterMaximus").GetComponent<Loader>();
    }

    private void OnTriggerStay(Collider colision)
    {
        if(colision.tag == "Player" )
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(CheckStars()){
                    sceaneLoaderMM.LoadNextSceane(1);
                }
            }
        }
    }

    public bool CheckStars()
    {
        if (beMMinstance.StarNumber == starInNeed) return true;
        return false;
    }
}
