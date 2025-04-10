using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player Player; 



   private void Start()
    {
        Player = GameObject.FindAnyObjectByType<Player>();
    }

 /*
       private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Player.Die();
        }
    }
   */



    void Update()
    {
        
    }
}
