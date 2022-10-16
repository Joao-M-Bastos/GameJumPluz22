using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    private BeMasterMaximus beMMinstance;

    private void Awake()
    {
        beMMinstance = GameObject.FindGameObjectWithTag("MasterMaximus").GetComponent<BeMasterMaximus>();
    }

    

    public void NextScene()
    {
        beMMinstance.LoadNextSceane();
    }

    public void ReturnToMenu()
    {
        beMMinstance.OpenScene(0);
    }
}
