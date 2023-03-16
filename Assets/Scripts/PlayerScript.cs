using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour{

    public int speed;                        //Speed in units/second the player moves
    public int score;                        //Playerscore
    public int lifes;                        //number of lives a player has
    public TextMeshProUGUI lifesText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start(){
        score = 0;
        speed = 14; 
        lifes = 3;
        lifesText.text = "Remaining Lives " + lifes.ToString();
        scoreText.text = "Score: " + score.ToString();

        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        //Move player object
        // Making sure movement is consistent over platforms by basing it on time not frames
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);

        //Check if player has reached eitheredge of screen
        if(transform.position.x < -11.09f){
            //push player back to edge
            transform.position = new Vector3(-11.09f, transform.position.y,0f);
        }
        if(transform.position.x > 11.09f){
            //push player back to edge
            transform.position = new Vector3(11.09f, transform.position.y,0f);  
        }        
    }

    //scoring, called from the FallingFishScript when a collision occurs between the player and a fish
    void ScorePoint(int pointsToAdd){
        score += pointsToAdd;
        scoreText.text = "Score: " + score.ToString();
    }
    //called from the FallingBombScript when a collision occurs between the player and a bomb
    void LoseLife(){
        lifes --;
        lifesText.text = "Remaining Lives: " + lifes.ToString();

        //check if GameOver
        if(lifes < 1){
            GameOver();
            lifes = 0;
        }
    }

    void GameOver(){  
        gameObject.SetActive(false);
        gameOverScreen.SetActive(true);

    }

    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame(){
        //This will close the Window the final, built Game will close. DOES NOT WORK IN EDITOR
        Application.Quit();
    }

}
