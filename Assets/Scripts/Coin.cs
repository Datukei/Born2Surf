using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }

        Destroy(gameObject);


    }





    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }
}
