using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{

    
    
    // private bool isMovingX = false;
    // private bool isMovingY = false;
    // private int[] possiblePositionsX = {-5, 0, 5};
    // private Vector3 moveDirection;
    private bool isJump, isDuck, isMoveX, isGameOver = false;
    private double JumpStartTime, DuckStartTime, MoveXStartTime;
    private float speedMoveRatio = 5f;
    private float defaultMoveTime = 1f; // in seconds
    private float defaultJumpTime = 0.5f;
    private Vector3 newPosition;
    private float xMoveInSteps, yMoveInSteps;
    private float xMove;
    private float yMove = 2f;
    private float laneWidth = 1.5f;

    private float duckSpeed;
    private float zSpeed = 5f;
    private float zAcceleration = 0.5f;
    
    //The re-sizing of the y scale to give the effect of dunk
    private float crouch = 0.3f;
    private float defaultScale;


    //Asi empieza y de aqui checo la posicion cuano tengo que codear de verdad lo que quiero que haga para despuer llamarlo con teclas
    private void Start(){
        isJump = isDuck = isMoveX  = false;
        defaultScale = this.transform.localScale.y;
        duckSpeed = -yMove * Time.fixedDeltaTime * 2f;
        xMove = laneWidth;
    }
    
    //Taken from Unitys page
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.GetComponent<Collider>().name);
        if(collision.GetComponent<Collider>().tag == "Finish"){
            isGameOver = true;
            CollideAnimation();
        }
    }

    //Notas pa que le entieda: Pico la tecla y llama a la funcion principal
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
           Duck();
        }
    }

    private void FixedUpdate()
    {
        if(!isGameOver){
            if (isMoveX)
            {
                if (xMoveInSteps > 0)
                    LeftAnimation();
                else
                    RightAnimation();
                IncrementX(xMoveInSteps);

                if (Now() - MoveXStartTime >= defaultMoveTime)
                {
                    isMoveX = false;
                    SetX(newPosition.x);
                    DefaultAnimation();
                }
            }

            if (isJump)
            {
                float jumpAngle = (float)((Now() - JumpStartTime) * 90 / defaultJumpTime);
                float jumpRadians = jumpAngle * Mathf.Deg2Rad;
                SetY(yMove * Mathf.Sin(jumpRadians));
                JumpAnimation();

                if (Now() - JumpStartTime >= defaultJumpTime * 2)
                {
                    isJump = false;
                    DefaultAnimation();
                    SetY(0);
                }
            }
            
            else if (isDuck)
            {            
                if(this.transform.position.y <= 0){
                    SetY(0);
                    DuckAnimation();
                }
                else{
                    DuckStartTime = Now();
                    IncrementY(duckSpeed);
                }

                if(Now() - DuckStartTime >= defaultJumpTime){
                    isDuck = false;
                    DefaultAnimation();
                }
            }

            walkZ();     
        }   
    }

    private void SetX(float value)
    {
        this.transform.position = new Vector3(value, this.transform.position.y, this.transform.position.z);
    }
    private void SetY(float value)
    {
        this.transform.position = new Vector3(this.transform.position.x, value, this.transform.position.z);
    }
    private void SetZ(float value)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, value);
    }
    private void SetC(float value)
    {
        this.transform.localScale = new Vector3 (this.transform.localScale.x, value, this.transform.localScale.z);
    }
    private void IncrementX(float value)
    {
        this.transform.position = new Vector3(value + this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
    private void IncrementY(float value)
    {
        this.transform.position = new Vector3(this.transform.position.x, value + this.transform.position.y, this.transform.position.z);
    }
    private void IncrementZ(float value)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, value + this.transform.position.z);
    }
    public float GetZSpeed(){ return zSpeed; }
    public bool GetIsGameOver(){ return isGameOver; }
    public float GetLaneWidth(){ return laneWidth; }

    private double Now(){ return Time.realtimeSinceStartupAsDouble; }

    //Aquí pongo lo que hace la función de verdad. Primero checo que no esté ya en la pision en la que quiero que esté
    private void MoveLeft()
    {
        if (newPosition.x < 0)
            LeftEdgeHit();
        else
        {
            isMoveX = true;
            MoveXStartTime = Now();
            newPosition += xMove * Vector3.left;
            MoveXStart();
        }
    }
    private void MoveRight()
    {
        if (newPosition.x > 0)
            RightEdgeHit();
        else
        {
            isMoveX = true;
            MoveXStartTime = Now();
            newPosition += xMove * Vector3.right;
            MoveXStart();
        }
    }
    private void MoveXStart()
    {
        // Player moves this much in 1 frame
        xMoveInSteps = (newPosition.x - this.transform.position.x) * Time.fixedDeltaTime / defaultMoveTime;
    }
    private void Jump()
    {

        // Spamming Jump is not allowed
        if (!isJump)
        {
            isJump = true;
            JumpStartTime = Now();
        }
        if (isDuck)
            isDuck = false;                
    
    }
    private void Duck()
    {

        // Spamming Duck is not allowed
        if (!isDuck)
        {
            isDuck = true;
            DuckStartTime = Now();
        }  

        if(isJump)
            isJump = false;
        
    }

    

    private void walkZ()
    {
        IncrementZ(zSpeed * Time.fixedDeltaTime);
        zSpeed += zAcceleration * Time.fixedDeltaTime;
        defaultMoveTime = speedMoveRatio / zSpeed;
    }

    private void LeftEdgeHit()
    {
        // Player Animation when character hits left edge
    }
    private void RightEdgeHit()
    {
        // Player Animation when character hits right edge
    }
    private void DuckAnimation()
    {
        // Player Animation when character ducks 
        SetC(crouch);
    }
    private void JumpAnimation()
    {
        // Player Animation when character jumps
        DefaultAnimation();
    }
    private void DefaultAnimation()
    {
        // Default Player Animation
        SetC(defaultScale);
    }
    private void CollideAnimation()
    {
        // Player Animation when character collides with obstacle
        DefaultAnimation();
    }
    private void LeftAnimation()
    {
        // Player Animation when character moves left
    }
    private void RightAnimation()
    {
        // Player Animation when character moves right
    }
}