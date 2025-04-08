using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;

    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed* Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
