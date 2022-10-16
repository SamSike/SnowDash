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
    private bool isJump, isDuck, isMoveX;
    private double JumpStartTime, DuckStartTime, MoveXStartTime;
    private float defaultMoveTime = 0.5f; // in seconds
    private Vector3 newPosition;
    private float xMoveInSteps;
    private float xMove = 5;
    private float yMove = 5;

    private float zSpeed = 5;
    private float zAcceleration = 0;
    
    private void Start(){
        isJump = isDuck = isMoveX  = false;
    }

    private void Update(){
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)){
            MoveRight();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)){
            MoveLeft();
        }
        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space)){
            Jump();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)){
            Duck();
        }
    }

    private void FixedUpdate(){

        if(isMoveX){
            if(xMoveInSteps > 0)
                LeftAnimation();
            else
                RightAnimation();
            IncrementX(xMoveInSteps);
            if(Time.realtimeSinceStartupAsDouble - MoveXStartTime >= defaultMoveTime){
                isMoveX = false;
                SetX(newPosition.x);
            }
        }

        if(isJump){
            // Change y over the course of defaultMoveTime seconds
            if(Time.realtimeSinceStartupAsDouble - JumpStartTime >= defaultMoveTime * 2){
                isJump = false;
                DefaultAnimation();
                SetY(0);
            }
            float jumpAngle = (float)((Time.realtimeSinceStartupAsDouble - JumpStartTime) * 90 / defaultMoveTime);
            float jumpRadians = jumpAngle * Mathf.Deg2Rad;
            SetY(yMove * Mathf.Sin(jumpRadians));
            JumpAnimation();
        }
        else if(isDuck){
            // Change y over the course of defaultMoveTime seconds
            if(Time.realtimeSinceStartupAsDouble - DuckStartTime >= defaultMoveTime){
                isDuck = false;
                DefaultAnimation();
            }
            DuckAnimation();
        }
        IncrementZ(zSpeed * Time.fixedDeltaTime);
        zSpeed += zAcceleration * Time.fixedDeltaTime;
    }

    private void SetX(float value){
        this.transform.position = new Vector3(value, this.transform.position.y, this.transform.position.z);
    }
    private void SetY(float value){
        this.transform.position = new Vector3(this.transform.position.x, value, this.transform.position.z);
    }
    private void SetZ(float value){
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, value);
    }

    private void IncrementX(float value){
        this.transform.position = new Vector3(value + this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
    private void IncrementY(float value){
        this.transform.position = new Vector3(this.transform.position.x, value + this.transform.position.y, this.transform.position.z);
    }
    private void IncrementZ(float value){
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, value + this.transform.position.z);
    }


    private void MoveLeft(){
        if(newPosition.x < 0)
                LeftEdgeHit();
        else
        {
            isMoveX = true;
            MoveXStartTime = Time.realtimeSinceStartupAsDouble;
            newPosition += xMove * Vector3.left;

            // Player moves this much in 1 frame
            xMoveInSteps = (newPosition.x - this.transform.position.x) * Time.fixedDeltaTime / defaultMoveTime;
        }
    }
    private void MoveRight(){
        if(newPosition.x > 0)
                RightEdgeHit();
        else
        {
            isMoveX = true;
            MoveXStartTime = Time.realtimeSinceStartupAsDouble;
            newPosition += xMove * Vector3.right;

            // Player moves this much in 1 frame
            xMoveInSteps = (newPosition.x - this.transform.position.x) * Time.fixedDeltaTime;
        }
    }
    private void Jump(){

        // Spamming Jump is not allowed
        if(!isJump){
            isJump = true;
            JumpStartTime = Time.realtimeSinceStartupAsDouble;
            if(isDuck)
                isDuck = false;
        }
    }
    private void Duck(){

        // Spamming Duck is not allowed
        if(!isDuck){
            isDuck = true;
            DuckStartTime = Time.realtimeSinceStartupAsDouble;
            if(isJump)
                isJump = false;
        }
    }

    private void LeftEdgeHit(){
        // Player Animation when character hits left edge
    }
    private void RightEdgeHit(){
        // Player Animation when character hits right edge
    }
    private void DuckAnimation(){
        // Player Animation when character ducks
    }
    private void JumpAnimation(){
        // Player Animation when character jumps
    }
    private void DefaultAnimation(){
        // Default Player Animation
    }
    private void LeftAnimation(){
        // Player Animation when character moves left
    }
    private void RightAnimation(){
        // Player Animation when character moves right
    }
}