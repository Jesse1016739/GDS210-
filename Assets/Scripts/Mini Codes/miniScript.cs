using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniScript : MonoBehaviour
{
    public GameObject mini;
    public Rigidbody miniRB;
    public Vector3 miniForce;
    public float deathTime = 5.0f;
    public bool isSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        //Defining the game object
        mini = gameObject;

        //Getting the game object's RigidBody
        miniRB = mini.GetComponent<Rigidbody>();

        //Defining the random force to applie to spawned game objects
        miniForce = new Vector3(Random.Range(-70, 70), Random.Range(-70, 70), Random.Range(-70, 70));

        //Adding the force to the game object via RigidBody
        //miniRB.AddForce(transform.forward + miniForce);

        StartCoroutine(death());
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned)
        {
            miniRB.AddForce(miniForce);
            isSpawned = true;
        }
    }
}
