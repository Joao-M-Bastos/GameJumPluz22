using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateALookAtCam : MonoBehaviour
{
    private Transform cameraPosition;

    private void Awake()
    {
        cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(cameraPosition, Vector3.up);
    }
}
