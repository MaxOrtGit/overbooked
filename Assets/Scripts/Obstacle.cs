using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speedChangeWhenHit;

    public bool removeOnImpact = false;
    public bool isCoin = false;
    public float spinSpeed = 0f;
    public bool isCar = false;
    public float SpawnSpacing = 40;
    public float addToHeight = 0f;



    public bool playSound = false;
    public float soundVolume = 1f;

    public AudioClip sound;

    [System.NonSerialized]
    public Vector3 size;

    private void Start()
    {
        if (gameObject.GetComponent<BoxCollider>() != null) {
            size = new Vector3(gameObject.GetComponent<BoxCollider>().size.x * transform.localScale.x, gameObject.GetComponent<BoxCollider>().size.y * transform.localScale.y, gameObject.GetComponent<BoxCollider>().size.z * transform.localScale.z);
        } else {
            size = transform.localScale;
        }

        if (isCar) {

        }
    }


    public Vector3 GetScale()
    {
        Vector3 sizee;
        if (gameObject.GetComponent<BoxCollider>() != null)
        {
            sizee = new Vector3(gameObject.GetComponent<BoxCollider>().size.x * transform.localScale.x, gameObject.GetComponent<BoxCollider>().size.y * transform.localScale.y, gameObject.GetComponent<BoxCollider>().size.z * transform.localScale.z);
        }
        else
        {
            sizee = transform.localScale;
        }
        return sizee;
    }

    private void Update()
    {
        if (spinSpeed != 0)
        {
            gameObject.transform.Rotate(new Vector3(0, spinSpeed * Time.deltaTime, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.parent.gameObject.GetComponent<Move>().speed *= speedChangeWhenHit;

            if (isCoin)
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<CoinCounter>().coinCount += 1;
            }

            if (playSound)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
            }

            if (removeOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }
}
