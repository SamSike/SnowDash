using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextOnScreen : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text highScoretext;
    public Text JumpHighText;
    public Text InvisibleText;
    public Text SpeedSlowText;
    public Text SpeedBoostText;
    public Text tutorialText;
    public Text gameOver;
    public Text gameOverScore;
    public Button Back;
    
    string teleporting = "inactive";
    string jumpboost = "inactive";
    string isinvinsible = "inactive";
    string slowing = "inactive";

    public Text armorcountText;
    private float addOnScore = 0;
    private float fadeWaitTime = 1f;
    private float gameOverdelay = 1f;

    private float currentHigh;

    void Start(){
        StartCoroutine(Tutorial());
        StartCoroutine(GameOver());
        highScoretext.text = "HIGH SCORE: "+ PlayerPrefs.GetFloat("currentHigh", 0).ToString("0");
    }

    void Update()
    {
        scoreText.text = "SCORE: "+ (addOnScore + player.transform.position.z).ToString("0");
        if((addOnScore + player.transform.position.z) > PlayerPrefs.GetFloat("currentHigh", 0)){
            PlayerPrefs.SetFloat("currentHigh", (addOnScore + player.transform.position.z));
            highScoretext.text = "HIGH SCORE: "+ (addOnScore + player.transform.position.z).ToString("0");
        }
        
        armorcountText.text = (player.GetArmorCount() / 2).ToString("0");
        JumpHighText.text = jumpboost;
        InvisibleText.text = isinvinsible;
        SpeedSlowText.text = slowing;
        SpeedBoostText.text = teleporting;
    }

    IEnumerator Tutorial(){
        yield return new WaitForSeconds(1);
        if(!player.GetIsGameOver())
            tutorialText.text = "Press Arrow Keys or WASD to Move";
        StartCoroutine(Fade());
        yield return new WaitForSeconds(4);
        if(!player.GetIsGameOver())
            tutorialText.text = "Space to Jump";
        StartCoroutine(Fade());
        yield return new WaitForSeconds(4);
        if(!player.GetIsGameOver())
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
    IEnumerator GameOver(){
        while(!player.GetIsGameOver())
            yield return new WaitForSeconds(gameOverdelay);
        gameOver.text = "GAME OVER";
        gameOverScore.text = scoreText.text;
        scoreText.text = "";
        highScoretext.text = "";
        tutorialText.text = "";
    }

    public void Play (){
        
        SceneManager.LoadScene("Menu");
    }

    public void SetAddOn(float value){
        this.addOnScore = value;
    }

    public float getAddOn(){
        return this.addOnScore;
    }

    public void SetjumpBoost(string value){
        this.jumpboost = value;
    }
    public void Setinvincible(string value){
        this.isinvinsible = value;
    }
    public void SetspeedSlow(string value){
        this.slowing = value;
    }
    public void SetSpeedBoost(string value){
        this.teleporting = value;
    }
}