using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision spikeCol)
    {
        //Checks if the player collides with the object
        if (spikeCol.gameObject.tag == "Player")
        {
            //Destroys the object to mimic picking it up and displaying a message
            spikeCol.gameObject.GetComponent<ThirdPersonCharacterController>().resourceAmount -= 1;
            spikeCol.gameObject.GetComponent<miniSpawn>().isHurt = true;
        }
    }
}
