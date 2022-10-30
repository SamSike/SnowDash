using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    private bool isJump, isDuck, isMoveX, isGameOver = false;
    private double JumpStartTime, DuckStartTime, MoveXStartTime;
    private float speedMoveRatio = 5f;
    private float defaultMoveTime = 1f; // in seconds
    private float defaultJumpTime = 0.5f;
    private Vector3 newPosition;
    private float xMoveInSteps, yMoveInSteps;
    private float xMove;
    private float yMove = 2f;
    private float laneWidth = 1.75f;

    private float rotateLeft = -45;
    private float rotateRight;
    private float duckSpeed;
    private float zSpeed = 10f;
    private float zAcceleration = 0.2f;
    
    //The re-sizing of the y scale to give the effect of dunk
    private float crouch = 0.3f;
    private float defaultScale;

    private bool isinvincible = false;

    //Asi empieza y de aqui checo la posicion cuano tengo que codear de verdad lo que quiero que haga para despuer llamarlo con teclas
    private void Start(){
        isJump = isDuck = isMoveX  = false;
        defaultScale = this.transform.localScale.y;
        duckSpeed = -yMove * Time.fixedDeltaTime * 2f;
        xMove = laneWidth;
        rotateRight = -rotateLeft;
    }
    
    //Taken from Unitys page
    void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponent<Collider>().tag == "Finish"){
            Debug.Log("I am in Game Over collider");
            if(!isinvincible){
                isGameOver = true;  
            }
                  
            Debug.Log(collision.GetComponent<Collider>().name);
            CollideAnimation();
        }
    }

    //Notas pa que le entieda: Pico la tecla y llama a la funcion principal
    private void Update()
    {
        if(!isGameOver){
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
    }

    private void FixedUpdate()
    {
        if(!isGameOver){
            if (isMoveX)
            {
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
            LeftAnimation();
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
            RightAnimation();
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
            SetCrouch(0);
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

        if(isJump){
            isJump = false;
            if(!isMoveX)
                DefaultAnimation();
        }
        
    }

    private double Now(){ return Time.realtimeSinceStartupAsDouble; }
    private void walkZ()
    {
        IncrementZ(zSpeed * Time.fixedDeltaTime);
        zSpeed += zAcceleration * Time.fixedDeltaTime;
        defaultMoveTime = speedMoveRatio / zSpeed;
    }
    private void LeftEdgeHit()
    {
        // Player Animation when character hits left edge
        // Also slow down player movement to make it harder
    }
    private void RightEdgeHit()
    {
        // Player Animation when character hits right edge
        // Also slow down player movement to make it harder
    }
    private void DuckAnimation()
    {
        // Player Animation when character ducks 
        SetCrouch(crouch);
    }
    private void JumpAnimation()
    {
        // Player Animation when character jumps
        // SetRotateY((float)(JumpStartTime - Now()) * 360 / defaultJumpTime);
        DefaultAnimation();
    }
    private void DefaultAnimation()
    {
        // Default Player Animation
        SetCrouch(defaultScale);
        SetRotateY(0);
    }
    private void CollideAnimation()
    {
        // Player Animation when character collides with obstacle
        //DefaultAnimation();
    }
    private void LeftAnimation()
    {
        // Player Animation when character moves left
        SetRotateY(rotateLeft);
    }
    private void RightAnimation()
    {
        // Player Animation when character moves right
        SetRotateY(rotateRight);
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
    private void SetCrouch(float value)
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
    private void SetRotateY(float value)
    {
        this.transform.eulerAngles = new Vector3(this.transform.rotation.x, value, this.transform.rotation.z);
    }

    public void SetZspeed(float value)
    {
        this.zSpeed = value;
    }

    public void SetyMove(float value)
    {
        this.yMove = value;
    }

    public void Setinvincible(bool value)
    {
        this.isinvincible = value;
    }

    public float GetyMove(){ return this.yMove; }
    public float GetZSpeed(){ return this.zSpeed; }
    public bool GetIsGameOver(){ return isGameOver; }
    public float GetLaneWidth(){ return laneWidth; }
}