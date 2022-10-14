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
    // private float xMoveTime = 3; // in seconds
    // private float yMoveTime = 3; // in seconds
    private Vector3 xMove = new Vector3(5,0,0);
    private Vector3 yMove = new Vector3(0,5,0);
    
    private void Update(){
        if(Input.GetAxis("Horizontal") > 0){
            if(this.transform.position.x > 0)
                RightEdgeHit();
            else
                MoveRight();
        }
        if(Input.GetAxis("Horizontal") < 0){
            if(this.transform.position.x < 0)
                LeftEdgeHit();
            else 
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
        // if (isMovingX && possiblePositionsX.Contains(this.position.x)){
        //     isMovingX = false;
        //     moveDirection = Vector3.zero;
        // }
        // if (isMoving)
        //     this.position += moveDirection / (moveTime * Time.fixedDeltaTime);
    }

    private void MoveRight(){
        // isMoving = true;
        this.transform.position += xMove;
    }
    private void MoveLeft(){
        // isMoving = true;
        this.transform.position -= xMove;
    }
    private void Jump(){
        // isMoving = true;
        this.transform.position += yMove;
    }
    private void Duck(){
        // isMoving = true;
        this.transform.position -= yMove;
    }

    private void LeftEdgeHit(){
        
    }

    private void RightEdgeHit(){

    }
}
