using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Par : MonoBehaviour
{
    Rigidbody rb;
    private float falldelay = 1f;
    private float destroydelay = 3f;
    public Collider Collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.useGravity = true;
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        rb.useGravity = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        rb.useGravity = true;
    }

    private IEnumerator fallplataform()
    {
        yield return new WaitForSeconds(falldelay);
        rb.useGravity = true;
        Destroy(gameObject, destroydelay);
    }
    
}
