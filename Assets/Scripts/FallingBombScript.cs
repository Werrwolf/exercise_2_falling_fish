using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBombScript : MonoBehaviour{

    public int speed;
    public GameObject player;       //holds a link to the player

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(12, 20);
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

        speed = Random.Range(12, 20);
    }

    void OnTriggerEnter2D(Collider2D other){

        //only collide with player, not other falling objects
        if (other.CompareTag("Player")){
            //Send message to Player to loose a live
            player.SendMessage("LoseLife");

            RespawnOnTop();
        }
    }

}

