using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFishScript : MonoBehaviour{
    public int speed;
    public GameObject player;       //holds a link to the player
    public int points;              //amount of points a fish is worth

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(12, 18);
    }

    // Update is called once per frame
    void Update(){
        //Move the object down the screen
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        
        //if object has fallen out of screen
        if(transform.position.y < - 8f){
            RespawnOnTop();
        }
    }

    void RespawnOnTop(){
        //reset it to top screen and randomize x-coordinate and speed
        float randNumber = Random.Range (-12f, 12f);
        Vector3 randPos = new Vector3(randNumber, 9, 0);
        transform.position = randPos;

        speed = Random.Range(12, 18);
    }

    //stores things colliding with fish under name "other"
    void OnTriggerEnter2D(Collider2D other){

        //only collide with player, not other falling objects
        if (other.CompareTag("Player")){
            RespawnOnTop();

            //Score points
            points = 5 * speed;
            player.SendMessage("ScorePoint", points);
        }
    }
}

