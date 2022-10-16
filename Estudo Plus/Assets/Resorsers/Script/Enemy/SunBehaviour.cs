using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour
{
    private BeMasterMaximus beMMinstance;

    private Transform sunFace;
    public float speed;

    private Rigidbody sunRB;

    private void Awake()
    {
        this.sunRB = this.GetComponent<Rigidbody>();
        beMMinstance = GameObject.FindGameObjectWithTag("MasterMaximus").GetComponent<BeMasterMaximus>();
        sunFace = GameObject.FindGameObjectWithTag("SunFacer").GetComponent<Transform>();
    }

    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        this.sunRB.velocity = sunFace.forward * speed;
    }

    private void OnTriggerEnter(Collider colisao)
    {
        if(colisao.tag == "Player")
        {
            beMMinstance.HasTakenDamage = true;
        }
    }


}