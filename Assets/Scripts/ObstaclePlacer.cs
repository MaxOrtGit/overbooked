using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstaclePlacer : MonoBehaviour
{

    public Obstick[] obstacles;
    public Obstick coin;
    public GameObject obstacleContainer;
    public int totalObstacles = 10;

    public int defaultSpacing = 60;

    public int xBounds = 25;


    public int coinCountdown;


    public Transform camera;
    int oldCamraZ = 0;

    List<GameObject> placedObstacles;

    int zLocation = 0;

    private void Start()
    {
        coinCountdown = coin.weight;




        placedObstacles = new List<GameObject>();
        zLocation += totalObstacles/2 * defaultSpacing;
        for (int i = 0; i < totalObstacles / 2; i++)
        {
           placedObstacles.Add(null);
        }
        int totalWeight = 0;
        for (int i = 0; i < obstacles.Length; i++)
        {
            totalWeight += obstacles[i].weight;
        }
        for (int i = 0; i < totalObstacles / 2; i++)
        {
            if (coinCountdown <= 0)
            {
                GameObject obstacle = coin.obs;
                Vector3 size = obstacle.transform.GetComponent<Obstacle>().GetScale();
                float xSpawn = Random.Range(-xBounds + size.x / 2, xBounds - size.x / 2);
                placedObstacles.Add(Instantiate(obstacle, new Vector3(xSpawn, size.y / 2 + 0.5f, zLocation), new Quaternion(0, 0, 0, 0), obstacleContainer.transform));
                zLocation += (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;
                coinCountdown += coin.weight;
            } else {
                int random = (int)Random.Range(0, totalWeight);
                int randomResault = 0;

                for (int j = 0; j < obstacles.Length; j++)
                {
                    random -= obstacles[j].weight;
                    if (random < 0)
                    {
                        randomResault = j;
                        break;
                    }
                }

                GameObject obstacle = obstacles[randomResault].obs;
                Vector3 size = obstacle.transform.GetComponent<Obstacle>().GetScale();
                float xSpawn = Random.Range(-xBounds + size.x / 2, xBounds - size.x / 2);
                placedObstacles.Add(Instantiate(obstacle, new Vector3(xSpawn + 6 * obstacle.GetComponent<Obstacle>().addToHeight, size.y / 2 + 0.5f + +obstacle.GetComponent<Obstacle>().addToHeight, zLocation), new Quaternion(0, 0, 0, 0), obstacleContainer.transform));
                zLocation += (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;
                coinCountdown -= (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;
            }
        }
    }

    void Update()
    {
        if (oldCamraZ < camera.transform.position.z - 100)
        {
            int totalWeight = 0;
            for (int i = 0; i < obstacles.Length; i++)
            {
                totalWeight += obstacles[i].weight;
            }

            GameObject ObsticleOne = placedObstacles[0];

            if (ObsticleOne == null){
                placedObstacles.RemoveAt(0);

                Destroy(ObsticleOne);

            } else if (ObsticleOne != null && ObsticleOne.transform.position.z < camera.transform.parent.position.z - 100)
            {

                placedObstacles.RemoveAt(0);

                Destroy(ObsticleOne);
            }
            if (coinCountdown <= 0)
            {
                GameObject obstacle = coin.obs;
                Vector3 size = obstacle.transform.GetComponent<Obstacle>().GetScale();
                float xSpawn = Random.Range(-xBounds + size.x / 2, xBounds - size.x / 2);
                placedObstacles.Add(Instantiate(obstacle, new Vector3(xSpawn, size.y / 2 + 0.5f, zLocation), new Quaternion(0, 0, 0, 0), obstacleContainer.transform));
                zLocation += (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;
                oldCamraZ += (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;
                coinCountdown += coin.weight;
            }
            else
            {

                int random = (int)Random.Range(0, totalWeight);
                int randomResault = 0;

                for (int i = 0; i < obstacles.Length; i++)
                {
                    random -= obstacles[i].weight;
                    if (random < 0)
                    {
                        randomResault = i;
                        break;
                    }
                }

                GameObject obstacle = obstacles[randomResault].obs;
                Vector3 size = obstacle.transform.GetComponent<Obstacle>().GetScale();
                Debug.Log(size);
                float xSpawn = Random.Range(-xBounds + size.x / 2, xBounds - size.x / 2);
                placedObstacles.Add(Instantiate(obstacle, new Vector3(xSpawn + 6 * obstacle.GetComponent<Obstacle>().addToHeight, size.y / 2 + 0.5f + obstacle.GetComponent<Obstacle>().addToHeight, zLocation), new Quaternion(0, 0, 0, 0), obstacleContainer.transform));

                oldCamraZ += (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;

                coinCountdown -= (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;
                zLocation += (int)obstacle.GetComponent<Obstacle>().SpawnSpacing;
            }

        }
    }
}

[System.Serializable]
public struct Obstick
{
    public GameObject obs;
    public int weight;
}

