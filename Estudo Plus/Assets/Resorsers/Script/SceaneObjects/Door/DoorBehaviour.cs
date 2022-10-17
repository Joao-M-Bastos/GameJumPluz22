using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private float starInNeed;

    private BeMasterMaximus beMMinstance;

    private void Awake()
    {
        beMMinstance = GameObject.FindGameObjectWithTag("MasterMaximus").GetComponent<BeMasterMaximus>();
    }

    private void OnTriggerStay(Collider colision)
    {
        if(colision.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(CheckStars()){
                    beMMinstance.GameOver(true);
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
