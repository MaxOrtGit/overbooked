using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform player;

    public float speed = 12f;

    public float bounds = 25;


    public float jumpforce = 100f;

    public bool grounded;
    public float buffer = 0f;

    public bool sliding = false;
    public bool isMoving = true;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float x = Input.GetAxis("Horizontal");
            x = 0;

            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && player.localPosition.x > -bounds + 2 && sliding == false)
            {
                x = -1;
            }
            //MOVE RIGHT
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && player.localPosition.x < bounds - 2 && sliding == false)
            {
                x = 1;
            }
            //MOVE LEFT SLIDE
            //float x = Input.GetAxis("Horizontal");
            //x = 0;
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && player.localPosition.x > -bounds + 2 && sliding == true)
            {
                //MOVE SPEED
                x = -0.5f;
            }
            //MOVE RIGHT SLIDE
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && player.localPosition.x < bounds - 2 && sliding == true)
            {
                //MOVE SPEED
                x = 0.5f;
            }
            Vector3 oldPos = player.localPosition;

            player.localPosition = new Vector3(oldPos.x + x * speed * Time.deltaTime, oldPos.y, oldPos.z);
            if (!grounded && player.position.y == 4.5 && buffer <= 0)
            {
                grounded = true;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            }

            buffer -= Time.deltaTime;
            if (grounded == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                buffer = 0.10f;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);
                grounded = false;
            }


            if (grounded == true && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                sliding = true;
                grounded = false;
                transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);


                StartCoroutine(SlideCooldown());
                //OLD SLIDE CODE (PlEASE KEEP)
                //  grounded = true;
                // sliding = false;
                // gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 100f, 0f), ForceMode.Impulse);
                // StandUp();
            }

            IEnumerator SlideCooldown()
            {

                yield return new WaitForSeconds(0.5f);

                grounded = true;
                sliding = false;
                //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 100f, 0f), ForceMode.Impulse);
                StandUp();




            }

         
        }

        void StandUp()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
        }
    }
}