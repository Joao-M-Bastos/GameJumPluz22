using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    private void Awake()
    {

    }

    public void LoadNextSceane(int i)
    {
        SceneManager.LoadScene(i);        
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);        
    }
}
