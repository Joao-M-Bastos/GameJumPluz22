using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeMasterMaximus : MonoBehaviour
{
    private int levelNum;

    private bool hasTakenDamage, gameOver, hasWin;

    private float starNumber;

    private void Awake()
    {
        levelNum = 1;
        hasWin = false;
        DontDestroyOnLoad(this);
    }

    private void OnLevelWasLoaded(int i)
    {
        starNumber = 0;
        if (i == 1)
        {
            if (hasWin)
            {
                GameObject.Find("OverMensageL").SetActive(false);
                return;
            }

            GameObject.Find("OverMensageW").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTakenDamage && !gameOver)
        {
            gameOver = true;
            GameOver(false);
        }
    }

    public void GameOver(bool good)
    {
        hasWin = good;
        SceneManager.LoadScene(1);        
    }

    public void LoadNextSceane()
    {
        levelNum++;
        SceneManager.LoadScene(levelNum);
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
