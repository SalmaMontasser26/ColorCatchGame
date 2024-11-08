using UnityEngine;

public class Spawner : MonoBehaviour
{
    //initialize the pickup and the different materials
    public GameObject pickupPrefab;
    public Material greenMaterial;
    public Material blueMaterial;
    public Material yellowMaterial;
    public int numberOfPickups = 40;
    //initialize the ranges for the prickups to appear
    public Vector2[] xRanges = { new Vector2(-45, -35), new Vector2(-120, -70), new Vector2(1, 260), new Vector2(235, 253), new Vector2(-225, 225)};
    public Vector2[] yRanges = { new Vector2(1, 4)};
    public Vector2[] zRanges = { new Vector2(-130, 30), new Vector2(16, 35), new Vector2(15, 25), new Vector2(-7, -200), new Vector2(-190, -180), new Vector2(-87, -74) };

    void Start()
    {
        //create the number of pickups assigned above
        for (int i = 0; i < numberOfPickups; i++)
        {
            SpawnPickups();
        }
    }

    public void SpawnPickups()
    {
            //randomly assign position values of x,y,z from the specified ranges above
            Vector2 xRange = xRanges[Random.Range(0, xRanges.Length)];
            Vector2 yRange = yRanges[Random.Range(0, yRanges.Length)];
            Vector2 zRange = zRanges[Random.Range(0, zRanges.Length)];

            float x = Random.Range(xRange.x, xRange.y);
            float y = Random.Range(yRange.x, yRange.y);
            float z = Random.Range(zRange.x, zRange.y);

            Vector3 randomPosition = new Vector3(x, y, z);
            
            //create a pickup prefab with the random position
            GameObject pickup = Instantiate(pickupPrefab, randomPosition, Quaternion.identity);
            Renderer renderer = pickup.GetComponent<Renderer>();
            int colorIndex = Random.Range(0, 3);

            //randomly choose a color for the prefab
            switch (colorIndex)
            {
                case 0:
                    renderer.material = greenMaterial;
                    break;
                case 1:
                    renderer.material = blueMaterial;
                    break;
                case 2:
                    renderer.material = yellowMaterial;
                    break;
            }  
    }
}

