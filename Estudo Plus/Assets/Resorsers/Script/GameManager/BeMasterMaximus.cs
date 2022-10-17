using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeMasterMaximus : MonoBehaviour
{
    private int levelNum;

    private bool hasTakenDamage, gameOver, countTime;

    private float starNumber, gameTimer;

    public SoundScript soundScript;

    private Player_Move player_Move;

    private GameObject canvasObject, winText, looseText;
    private GameObject[] starsImages;

    private void Awake()
    {
        soundScript = GameObject.FindGameObjectWithTag("SoundSource").GetComponent<SoundScript>();

        levelNum = 1;
        countTime = false;
        DontDestroyOnLoad(this);
    }

    private void OnLevelWasLoaded(int i)
    {
        starNumber = 0;
        gameOver = false;        
        if (i > 0)
        {
            gameTimer = 0;
            countTime = true;
            GetGameObjects();
            canvasObject.SetActive(false);
            player_Move = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (hasTakenDamage && !gameOver)
        {            
            GameOver(false);
        }else

        if (countTime)
            gameTimer += Time.deltaTime;

        GameObject[] MMs = GameObject.FindGameObjectsWithTag("MasterMaximus");

        if (MMs.Length > 1) Destroy(MMs[1]);
    }

    //-------------------------------Update Isntances -----------------------------

    public void GetGameObjects()
    {
        canvasObject = GameObject.FindGameObjectWithTag("canvas");
        looseText = GameObject.Find("OverMensageL");
        winText = GameObject.Find("OverMensageW");
        starsImages = GameObject.FindGameObjectsWithTag("StarHud");
    }

    public void GameOver(bool good)
    {
        if (levelNum == 2)
            levelNum = 1;
        else
            levelNum++;

        gameOver = true;

        player_Move.WinLooseAnim(good);

        this.StartCoroutine(ActiveCanvasCooldown(good));
    }

    public IEnumerator ActiveCanvasCooldown(bool good)
    {
        yield return new WaitForSeconds(3f);
        canvasObject.SetActive(true);

        ShowTimer();
        ShowStars();

        countTime = false;

        if (good)
        {
            looseText.SetActive(false);
            soundScript.PlayVitoria();
        }
        else
        {
            winText.SetActive(false);
            soundScript.PlayDerrota();
        }
    }

    public void ShowTimer()
    {
        string stgminutos, stgsegundos, stgmilisegundos;
        float minutos = Mathf.Floor(gameTimer / 60);
        if (minutos < 10) stgminutos = "0" + minutos;
        else stgminutos = minutos.ToString();


        float segundos = Mathf.Floor(gameTimer - (minutos * 60));
        if (segundos < 10) stgsegundos = "0" + segundos;
        else stgsegundos = segundos.ToString();

        float miliseconds = Mathf.Floor((gameTimer - (segundos + (minutos * 60))) * 100);
        if (miliseconds < 10) stgmilisegundos = "0" + miliseconds;
        else stgmilisegundos = miliseconds.ToString();

        string timerString = stgminutos + ":" + stgsegundos + ":" + stgmilisegundos;

        GameObject.Find("txt_Time").GetComponent<TMPro.TextMeshProUGUI>().text = timerString;


    }

    public void ShowStars()
    {            
        if(starNumber < 1)
            starsImages[0].SetActive(false);

        if(starNumber < 2)
            starsImages[1].SetActive(false);

        if (starNumber < 3)
            starsImages[2].SetActive(false);
    }



    public void LoadNextSceane()
    {
        OpenScene(levelNum);
    }

    public void OpenScene(int i)
    {
        if (hasTakenDamage)
        {
            hasTakenDamage = false;
            levelNum = 1;
            i = 0;
        }        
        
        gameOver = false;
        SceneManager.LoadScene(i);
    }

    public bool HasTakenDamage
    {
        get { return HasTakenDamage; }
        set { hasTakenDamage = value; }
    }

    public bool HasOverGame
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public float StarNumber
    {
        get { return starNumber; }
        set { starNumber = value; }
    }

    public float GameTimer
    {
        get { return gameTimer; }
        set { gameTimer = value; }
    }
}
