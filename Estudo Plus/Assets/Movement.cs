using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private int startPointing = 0;
    public Transform[] points;

    private int i;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPointing].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < .1f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].transform.position, speed * Time.deltaTime);

    }

}
