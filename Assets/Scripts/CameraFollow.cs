using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    Vector3 offset;


  private void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
