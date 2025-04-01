using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player Player; 



   private void Start()
    {
        Player = GameObject.FindAnyObjectByType<Player>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Player.Die();
        }
    }




    void Update()
    {
        
    }
}
