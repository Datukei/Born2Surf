using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement PlayerMovement; 



   private void Start()
    {
        PlayerMovement = GameObject.FindAnyObjectByType<PlayerMovement>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement.Die();
        }
    }




    void Update()
    {
        
    }
}
