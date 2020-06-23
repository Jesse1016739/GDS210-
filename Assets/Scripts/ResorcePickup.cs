using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResorcePickup : MonoBehaviour
{
    public float rotSpeed;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public float amplitude = 0.5f;
    public float frequency = 1f;

    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }
    void Update()
    {
        //Gives the object it's rotation
        gameObject.transform.Rotate (rotSpeed, rotSpeed, rotSpeed);

        //Uses maths to calculate bobbing of the object.
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        //Bobs the object up and down
        transform.position = tempPos;
    }
    void OnCollisionEnter(Collision resourceCol)
    {
        //Checks if the player collides with the object
        if (resourceCol.gameObject.tag == "Player")
        {
            //Destroys the object to mimic picking it up and displaying a message
            Destroy(gameObject);
            resourceCol.gameObject.GetComponent<ThirdPersonCharacterController>().resourceAmount += 1;
            Debug.Log("You got a resource!");
        }
    }
}
