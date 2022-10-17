using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    void Update()
    {
        scoreText.text = "SCORE: "+ player.position.z.ToString("0");
    }
}
