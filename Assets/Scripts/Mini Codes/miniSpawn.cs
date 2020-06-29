using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class miniSpawn : MonoBehaviour
{
    public GameObject minis;
    public GameObject[] spawners;

    public int randomMiniSpawn;

    public bool isHurt = false;

    public float numberOfMinis;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        randomMiniSpawn = Random.Range(0, 4);

        if (isHurt == true)
        {
            numberOfMinis += 1;
            Instantiate(minis, spawners[randomMiniSpawn].transform);

            Debug.Log("You have lost a gnome!");

            isHurt = false;
        }




        //if (Input.GetButtonDown("Fire1"))
        //{
        //    numberOfMinis += 1;
        //    Instantiate(minis, spawners[randomMiniSpawn].transform);

        //    Debug.Log("You have killed a gnome. You Monster.");

        //}

        //if (Input.GetButtonDown("Fire2"))
        //{
        //    Debug.Log("Thanks for playing!  " + numberOfMinis + " of gnomes were harmed in the making of this game!");
        //}
    }
}
