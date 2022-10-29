using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextOnScreen : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text highScoretext;
    public Text tutorialText;
    public Text gameOver;
    public Text gameOverScore;

    private float fadeWaitTime = 1f;

    void Start(){
        StartCoroutine(Tutorial());
    }

    void Update()
    {
        scoreText.text = "SCORE: "+ player.transform.position.z.ToString("0");
        if(player.GetIsGameOver()){
            gameOver.text = "GAME OVER";
            gameOverScore.text = scoreText.text;
        }
    }

    IEnumerator Tutorial(){
        yield return new WaitForSeconds(1);
        tutorialText.text = "Press Arrow Keys or WASD to Move";
        StartCoroutine(Fade());
        yield return new WaitForSeconds(4);
        tutorialText.text = "Space to Jump";
        StartCoroutine(Fade());
        yield return new WaitForSeconds(4);
        tutorialText.text = "Shift to Duck";
        StartCoroutine(Fade());
    }

    IEnumerator Fade(){        
        tutorialText.color = new Color(tutorialText.color.r, tutorialText.color.g, tutorialText.color.b, 1);
        yield return new WaitForSeconds(2);
        for(float i=1; i >= 0; i -= 0.1f){
            yield return new WaitForSeconds(fadeWaitTime * 0.1f);
            tutorialText.color = new Color(tutorialText.color.r, tutorialText.color.g, tutorialText.color.b, i);
        }
        tutorialText.color = new Color(tutorialText.color.r, tutorialText.color.g, tutorialText.color.b, 0);
    }
}
