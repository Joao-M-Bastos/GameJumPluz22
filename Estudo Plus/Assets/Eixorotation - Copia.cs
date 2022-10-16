using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eixorotation : MonoBehaviour
{
    public int VelRotation;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, VelRotation * Time.deltaTime, 0);
    }
}
