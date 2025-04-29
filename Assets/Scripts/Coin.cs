using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    public int value;
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }

        Destroy(gameObject);
        CoinCounter.Instance.IncreaseCoins(value);

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
