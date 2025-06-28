using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    // add code gameOBJ Chair
    Teacher  teacherCode; // techerCode dai diem cho script Teacher
    bool playerIsOnChair ; 

    void Start()
    { 
        teacherCode = FindObjectOfType<Teacher>();
    }

     public void Update()
    {
        Debug.Log("playerIsOnchair: " + playerIsOnChair);
        if (playerIsOnChair )
        {
            teacherCode.SetPlayerOnChair(true);
        }
        else if(!playerIsOnChair )
        {
            teacherCode.SetPlayerOnChair(false);
        }

        
       
    }
    void OnTriggerEnter2D(Collider2D other) // khi ngoi ten ghe
    {
        if (other.CompareTag("Player")) // mo unity gan tag "Player" vao Player
        {
           
            playerIsOnChair = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) // khi roi khoi ghe
    {
        if (other.CompareTag("Player"))
        {
           
            playerIsOnChair = false;
        }
    }

}