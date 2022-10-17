using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour
{

    //------------------------------------------- VARIAVEIS ---------------------------------------
    private float AxisX;

    private BeMasterMaximus beMMinstance;

    private Rigidbody playerRB;
    private LayerMask groundLayerMask;

    [SerializeField] private float maxDoubleJumpCount;

    [SerializeField] private Transform rayCastUpper;
    [SerializeField] private Transform rayCastDown;

    public Animator characterAnimator, sunAnimator;

    private SoundScript soundScript;

    public float playerBaseSpeed, playerSpeed, playerJumpForce, coeficienteDesaceleracao, coeficienteGravidade;

    private float turnSmoothTime, turnSmoothVelocity, doubleJumpCount;

    private void Awake()
    {
        this.groundLayerMask = LayerMask.GetMask("Ground");
        beMMinstance = GameObject.FindGameObjectWithTag("MasterMaximus").GetComponent<BeMasterMaximus>();
        soundScript = GameObject.FindGameObjectWithTag("SoundSource").GetComponent<SoundScript>();
        sunAnimator = GameObject.FindGameObjectWithTag("SunEnemy").GetComponent<Animator>();
        this.playerRB = this.GetComponent<Rigidbody>();
        this.turnSmoothTime = 0.1f;
        GetInSpawnPoint();
    }

    private void OnLevelWasLoaded(int level)
    {
        GetInSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!beMMinstance.HasOverGame)
        {
            UpdateValues();

            if (CanMove()) Move();
        }
        else
            this.playerRB.isKinematic = true;
    }

    //--------------------------------- UPDATE INSTANCES --------------------------------


    public void WinLooseAnim(bool good)
    {
        this.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        if (good)
        {
            
            this.characterAnimator.SetTrigger("Win");
        }
        else
        {
            this.characterAnimator.SetTrigger("Lose");
            this.sunAnimator.SetTrigger("Catch");
        }
            
    }

    public void UpdateValues()
    {
        if (OnGround() && doubleJumpCount != maxDoubleJumpCount) doubleJumpCount = maxDoubleJumpCount;

        if (this.playerSpeed != this.playerBaseSpeed) UpdateSpeed();

        GravityUp();
        FixAxisZ();
        UpdateAnimator();
    }

    public void UpdateSpeed()
    {
        this.playerSpeed = this.playerBaseSpeed;
    }
    public void UpdateAnimator()
    {
        this.characterAnimator.SetBool("OnGround", OnGround());
    }

    public void GravityUp()
    {
        if (!OnGround())
        {
            //Aumenta for�a da gravidade
            this.playerRB.AddForce(0, -coeficienteGravidade, 0);
        }
    }

    public void FixAxisZ()  
    {
        if (this.transform.position.z != 0) this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (this.playerRB.velocity.z != 0) this.playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y, 0);
    }

    public void GetInSpawnPoint()
    {
        Transform SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;

        if (SpawnPoint != null)
        {
            this.transform.position = SpawnPoint.position;
            this.transform.rotation = SpawnPoint.rotation;
        }
    }



    //----------------------------------------- ACTIONS -----------------------------------

    public void Move()
    {        
        Vector3 direction;

        AxisX = Input.GetAxis("Horizontal");

        direction = new Vector3(-AxisX, 0, 0).normalized;

        Walk(direction);

        if (Input.GetKeyDown(KeyCode.Space)) Jump(JumpType());
    }

    public void Walk(Vector3 direction)
    {
        if (direction.magnitude != 0)
        {
            this.characterAnimator.SetBool("Run", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * playerSpeed;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            if (CanSpeedUp(moveDir.x))
                this.playerRB.AddForce(moveDir * playerSpeed, ForceMode.Acceleration);


            if (CanClimbstep())
            {
                transform.position += new Vector3(0, 0.5f, 0) + (transform.forward * 0.5f);
                playerRB.velocity -= new Vector3(0, playerRB.velocity.y, 0);
            }
        }
        else
        {
            this.characterAnimator.SetBool("Run", false);

            Friction();
        }
    }

    public void Jump(float jumpType)
    {
        float newYSpeed = playerRB.velocity.y;
        switch (jumpType)
        {
            case 0:
                break;
            case 1:
                newYSpeed = playerJumpForce;
                this.characterAnimator.SetTrigger("Jump");
                this.soundScript.PlayJumpEffect();
                break;
            case 2:
                newYSpeed = playerJumpForce;
                this.characterAnimator.SetTrigger("Jump");
                this.soundScript.PlayJumpEffect();
                doubleJumpCount--;
                break;
        }

        this.playerRB.velocity = new Vector3(playerRB.velocity.x, newYSpeed, 0);
    }

    public void Friction()
    {
        Vector3 playerActualSpeed;
        playerActualSpeed = this.playerRB.velocity;

        float coeficienteDesaceleracaoatual = coeficienteDesaceleracao;

        if (!OnGround())
            coeficienteDesaceleracaoatual -= coeficienteDesaceleracao / 1.3f;

        if (playerActualSpeed.x > 1)
            playerActualSpeed.x -= coeficienteDesaceleracaoatual * Time.deltaTime;
        else if (playerActualSpeed.x < -1)
            playerActualSpeed.x += coeficienteDesaceleracaoatual * Time.deltaTime;
        else
            playerActualSpeed.x = 0;

        this.playerRB.velocity = playerActualSpeed;
    }


    //-------------------------------------- TESTS ----------------------------------

    public bool OnGround()
    {
        if (Physics.Raycast(this.transform.position, -Vector3.up, 1.2f, groundLayerMask)) return true;
            
        return false;
    }

    public float JumpType()
    {
        if (OnGround()) return 1;
        else if (doubleJumpCount > 0) return 2;
        return 0;
    }

    public bool CanClimbstep()
    {
        //Debug.DrawRay(rayCastDown.position, Vector3.forward);
        if (Physics.Raycast(rayCastDown.position, this.transform.forward, 0.05f, groundLayerMask))
            if (!Physics.Raycast(rayCastUpper.position, this.transform.forward, 0.05f, groundLayerMask))
                return true;

        return false;
    }
    
    public bool CanSpeedUp(float moveDir)
    {
        if (this.playerRB.velocity.x > 4 && moveDir >= 1)
        {
            this.playerRB.velocity = new Vector3(4, playerRB.velocity.y, 0);
            return false;
        }


        if (this.playerRB.velocity.x < -4 && moveDir <= -1)
        {
            this.playerRB.velocity = new Vector3(-4, playerRB.velocity.y, 0);
            return false;
        }

        return true;
    }

    public bool CanMove()
    {
        //if(OnGround())
        return true;

        return false;
    }
}
