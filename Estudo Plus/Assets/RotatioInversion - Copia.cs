using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatioInversion : MonoBehaviour
{
    Vector3 relativePosition;
    Vector3 startPosition;
    Quaternion targetposition;
    void Start()
    {
        startPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
      

    }
     IEnumerator inverseRotation()
    {
        yield return new WaitForSeconds(3f);
    }
}
