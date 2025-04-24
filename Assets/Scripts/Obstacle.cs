using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player Player; 

    private void Start()
    {
        Player = GameObject.FindAnyObjectByType<Player>();
    }


    void Update()
    {

    }
}



