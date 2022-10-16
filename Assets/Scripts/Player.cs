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
    private float defaultMoveTime = 1f; // in seconds
    private Vector3 newPosition;
    private float xMoveInSteps;
    private float xMove = 1f;
    private float yMove = 1f;

    private float zSpeed = 5f;
    private float zAcceleration = 0.1f;

    private void Start()
    {
        isJump = isDuck = isMoveX = false;
    }

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

        if (isMoveX)
        {
            if (xMoveInSteps > 0)
                LeftAnimation();
            else
                RightAnimation();
            IncrementX(xMoveInSteps);

            if (Time.realtimeSinceStartupAsDouble - MoveXStartTime >= defaultMoveTime)
            {
                isMoveX = false;
                SetX(newPosition.x);
                DefaultAnimation();
            }
        }

        if (isJump)
        {
            float jumpAngle = (float)((Time.realtimeSinceStartupAsDouble - JumpStartTime) * 90 / defaultMoveTime);
            float jumpRadians = jumpAngle * Mathf.Deg2Rad;
            SetY(yMove * Mathf.Sin(jumpRadians));
            JumpAnimation();

            if (Time.realtimeSinceStartupAsDouble - JumpStartTime >= defaultMoveTime * 2)
            {
                isJump = false;
                DefaultAnimation();
                SetY(0);
            }
        }
        else if (isDuck)
        {
            DuckAnimation();
            if (Time.realtimeSinceStartupAsDouble - DuckStartTime >= defaultMoveTime)
            {
                isDuck = false;
                DefaultAnimation();
            }
        }
        IncrementZ(zSpeed * Time.fixedDeltaTime);
        zSpeed += zAcceleration * Time.fixedDeltaTime;
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


    private void MoveLeft()
    {
        if (newPosition.x < 0)
            LeftEdgeHit();
        else
        {
            isMoveX = true;
            MoveXStartTime = Time.realtimeSinceStartupAsDouble;
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
            MoveXStartTime = Time.realtimeSinceStartupAsDouble;
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
            JumpStartTime = Time.realtimeSinceStartupAsDouble;
            if (isDuck)
                isDuck = false;
        }
    }
    private void Duck()
    {

        // Spamming Duck is not allowed
        if (!isDuck)
        {
            isDuck = true;
            DuckStartTime = Time.realtimeSinceStartupAsDouble;
            if (isJump)
                isJump = false;
        }
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
    }
    private void JumpAnimation()
    {
        // Player Animation when character jumps
    }
    private void DefaultAnimation()
    {
        // Default Player Animation
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