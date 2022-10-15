using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerPosition;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(playerPosition, Vector3.up);
    }
}
