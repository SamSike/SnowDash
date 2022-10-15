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
    private float defaultMoveTime = 1; // in seconds
    private Vector3 newPosition = Vector3.zero;
    private Vector3 xMoveInSteps, yMoveInSteps;
    private float xMove = 5;
    //private float yMove = 5;
    
    private void Update(){
        if(Input.GetAxis("Horizontal") > 0){
                MoveRight();
        }
        if(Input.GetAxis("Horizontal") < 0){
                MoveLeft();
        }
        if(Input.GetAxis("Vertical") > 0){
            Jump();
        }
        if(Input.GetAxis("Vertical") < 0){
            Duck();
        }
    }

    private void FixedUpdate(){

        if(isMoveX){
            if(xMoveInSteps.x > 0)
                LeftAnimation();
            else
                RightAnimation();
        }


        if(isJump){
            // Change y over the course of defaultMoveTime seconds
            if(Time.realtimeSinceStartupAsDouble - JumpStartTime >= defaultMoveTime * 2)
                isJump = false;
            JumpAnimation();
        }
        else if(isDuck){
            // Change y over the course of defaultMoveTime seconds
            if(Time.realtimeSinceStartupAsDouble - DuckStartTime >= defaultMoveTime)
                isDuck = false;
            DuckAnimation();
        }
    }

    private void MoveLeft(){
        if(newPosition.x < 0)
                LeftEdgeHit();
        else
        {
            isMoveX = true;
            MoveXStartTime = Time.realtimeSinceStartupAsDouble;
            newPosition += xMove * Vector3.left;
            xMoveInSteps = (newPosition - this.transform.position) * Time.fixedDeltaTime;
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
            xMoveInSteps = (newPosition - this.transform.position) * Time.fixedDeltaTime;
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
    private void LeftAnimation(){
        // Player Animation when character moves left
    }
    private void RightAnimation(){
        // Player Animation when character moves right
    }
}