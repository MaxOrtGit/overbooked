using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetPlacer : MonoBehaviour
{

    public List<GameObject> streets;
    public GameObject streetContainer;
    public int totalStreets = 10;

    public int streetZ = 40;


    public Transform camera;
    int oldCamraZ = 0;

    List<GameObject> placedStreets;

    int zLocation = 0;

    private void Start()
    {
        placedStreets = new List<GameObject>();
        for (int i = 0; i < totalStreets; i++)
        {
            placedStreets.Add(Instantiate(streets[(int)Random.Range(0, streets.Count)], new Vector3(0, 0, zLocation), new Quaternion(0, 0, 0, 0), streetContainer.transform));
            zLocation += streetZ;
        }
    }

    void Update()
    {
        if (oldCamraZ < camera.transform.position.z - 100)
        {
            oldCamraZ += streetZ;
            GameObject streetOne = placedStreets[0];

            placedStreets.RemoveAt(0);

            Destroy(streetOne);

            placedStreets.Add(Instantiate(streets[(int)Random.Range(0, streets.Count)], new Vector3(0, 0, zLocation), new Quaternion(0, 0, 0, 0), streetContainer.transform));

            zLocation += streetZ;
        }
    }
}
