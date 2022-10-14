using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class Player : PlayableAsset, MonoBehaviour
{
    // private bool isMovingX = false;
    // private bool isMovingY = false;
    // private int[] possiblePositionsX = {-5, 0, 5};
    // private Vector3 moveDirection;
    // private float xMoveTime = 3; // in seconds
    // private float yMoveTime = 3; // in seconds
    

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        return Playable.Create(graph);
    }

    private void Update(){
        if(Input.GetAxis("Horizontal") > 0){
            if(this.position.x > 0)
                RightEdgeHit();
            else
                MoveRight();
        }
        if(Input.GetAxis("Horizontal") < 0){
            if(this.position.x < 0)
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
        isMoving = true;
    }
    private void MoveLeft(){
        isMoving = true;
    }
    private void Jump(){
        isMoving = true;
    }
    private void Duck(){
        isMoving = true;
    }
}
