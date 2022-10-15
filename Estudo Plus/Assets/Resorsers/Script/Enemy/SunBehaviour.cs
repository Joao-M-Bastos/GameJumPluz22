using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour
{
    [SerializeField] private BeMasterMaximus MMinstance;

    public Transform sunFace;
    public float speed;

    private Rigidbody sunRB;

    private void Awake()
    {
        this.sunRB = this.GetComponent<Rigidbody>();
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
            MMinstance.HasTakenDamage = true;
        }
    }
}