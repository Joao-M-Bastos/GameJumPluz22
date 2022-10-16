using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeMasterMaximus : MonoBehaviour
{
    private Player_Move playerMove;

    private int levelNum;

    private bool hasTakenDamage, gameOver, hasWin;

    private float starNumber;

    private void Awake()
    {
        levelNum = 1;
        hasWin = false;
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>();
        DontDestroyOnLoad(this);
    }

    private void OnLevelWasLoaded(int i)
    {
        starNumber = 0;
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
