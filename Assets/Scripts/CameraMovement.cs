using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    float origY;
    private void Start()
    {
        offset = transform.position - player.position;
        origY = transform.position.y;


    }

    private void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        targetPos.y = origY;
        transform.position = targetPos;
    }


}