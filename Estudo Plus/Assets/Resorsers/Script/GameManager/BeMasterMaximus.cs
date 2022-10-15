using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeMasterMaximus : MonoBehaviour
{
    private Player_Move playerMove;

    private GameObject[] carry;

    private bool hasTakenDamage;

    private float starNumber;

    private void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>();
        carry = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
        DontDestroyOnLoad(carry[0]);
    }

    private void OnLevelWasLoaded(int i)
    {
        starNumber = 0;
        CheckIfDouble();
        PutPlayerInSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //if (hasTakenDamage) Debug.Log("Se fudeu");
    }

    private void CheckIfDouble()
    {
        carry = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");

        if (carry.Length > 1)
        {
            Destroy(carry[1]);
        }
    }

    private void PutPlayerInSpawnPoint()
    {
        Transform SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        playerMove.transform.position = SpawnPoint.position;
        playerMove.transform.rotation = SpawnPoint.rotation;
    }

    public bool HasTakenDamage
    {
        get { return HasTakenDamage; }
        set { hasTakenDamage = value; }
    }

    public float StarNumber
    {
        get { return starNumber; }
        set { starNumber = value; }
    }
}
