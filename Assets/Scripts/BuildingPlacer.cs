using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{

    public List<GameObject> buildings;
    public GameObject buildingContainer;
    public int totalBuildingsSide = 20;

    public int buildingZ = 20;
    public int buildingSpaceingX = 40;


    public Transform camera;
    int oldCamraZ = 0;

    List<GameObject> placedBuildings;

    int zLocation = 0;

    private void Start()
    {
        placedBuildings = new List<GameObject>();
        for (int i = 0; i < totalBuildingsSide; i++)
        {

            placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(buildingSpaceingX, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));
            placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(-buildingSpaceingX, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));

            placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(buildingSpaceingX + buildingZ, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));
            placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(-buildingSpaceingX - buildingZ, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));

            placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(buildingSpaceingX + buildingZ * 2, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));
            placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(-buildingSpaceingX - buildingZ * 2, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));

            zLocation += buildingZ;
        }
    }

    void Update()
    {
        if(oldCamraZ < camera.transform.position.z - 100)
        {
            if (zLocation == 10000)
            {
                zLocation += buildingZ;
            }
            else
            {
                oldCamraZ += buildingZ;
                GameObject buildOne = placedBuildings[0];
                GameObject buildTwo = placedBuildings[1];
                GameObject buildThree = placedBuildings[2];
                GameObject buildFour = placedBuildings[3];
                GameObject buildFive = placedBuildings[4];
                GameObject buildSix = placedBuildings[5];

                placedBuildings.RemoveAt(0);
                placedBuildings.RemoveAt(0);
                placedBuildings.RemoveAt(0);
                placedBuildings.RemoveAt(0);
                placedBuildings.RemoveAt(0);
                placedBuildings.RemoveAt(0);

                Destroy(buildOne);
                Destroy(buildTwo);
                Destroy(buildThree);
                Destroy(buildFour);
                Destroy(buildFive);
                Destroy(buildSix);

                placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(buildingSpaceingX, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));
                placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(-buildingSpaceingX, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));

                placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(buildingSpaceingX + buildingZ, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));
                placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(-buildingSpaceingX - buildingZ, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));

                placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(buildingSpaceingX + buildingZ * 2, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));
                placedBuildings.Add(Instantiate(buildings[(int)Random.Range(0, buildings.Count)], new Vector3(-buildingSpaceingX - buildingZ * 2, 0, zLocation), new Quaternion(0, 0, 0, 0), buildingContainer.transform));


                zLocation += buildingZ;
            }
        }
    }
}
