using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public Vector3[] lanePositions = new Vector3[3];
    public float[] laneXPositions = new float[] { -1.5f, 0f, 1.5f }; // Customize to match your lanes
    public bool isFirstTile = false;



   void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnCoins();
        SpawnObstacle();
        SpawnCoins();
        SpawnObstacle();

    }
    /* void Start()
     {
         groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

         if (!isFirstTile)
         {
             SpawnCoins();
             SpawnObstacle();
         }
     }
    */

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }




    void Update()
    {
        
    }

    public GameObject coinPrefab;
    public GameObject ObstacleSandPrefab;


   void SpawnObstacle ()
     {
         int obstacleSpawnIndex = Random.Range(2, 5);
         Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

         Instantiate(ObstacleSandPrefab, spawnPoint.position, Quaternion.identity, transform);
     }

    /*
  void SpawnObstacle()
  {
      int laneIndex = Random.Range(0, 3); // 0, 1, or 2
      float xPos = laneXPositions[laneIndex];

      Vector3 spawnPos = new Vector3(xPos, 0, transform.position.z + Random.Range(5f, 10f)); // Adjust y and z
      Instantiate(ObstacleSandPrefab, spawnPos, Quaternion.identity, transform);
  }


  */



     void SpawnCoins()
     {

         int coinsToSpawn = 100;
         for (int i = 0; i < coinsToSpawn; i++) ;
         GameObject temp = Instantiate(coinPrefab);
         temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
     }
  

    /*
    void SpawnCoins()
    {
        int numCoins = 1;

        for (int i = 0; i < numCoins; i++)
        {
            int laneIndex = Random.Range(0, 3);
            float xPos = laneXPositions[laneIndex];
            float zOffset = Random.Range(2f, 8f);

            Vector3 spawnPos = new Vector3(xPos, 1f, transform.position.z + zOffset); // y=1 for visibility
            Instantiate(coinPrefab, spawnPos, Quaternion.identity, transform);
        }
    }
    */

    Vector3 GetRandomPointInCollider(Collider collider)
    {

        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;


    }

}
    


