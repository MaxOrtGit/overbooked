using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0f;
    public float baseAcceleration = 0.25f;
    public float change = 500;
    public float changeScale = 4;
    public float output;

    public bool isMoving = true;

    public Animator anima;

    void Update()
    {
        if (isMoving) {
            anima.SetFloat("MultiplySpeed", speed);
            output = ((change / (speed + 0.1f)) * changeScale + baseAcceleration);
            speed += output * Time.deltaTime;
            Vector3 oldPos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(oldPos.x, oldPos.y, oldPos.z + speed * Time.deltaTime);
        }
    }
}
