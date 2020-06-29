using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
	[SerializeField] private Transform player;
	private GameMaster gm;
	

	private void OnTriggerEnter(Collider other)
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		player.transform.position = gm.LastCheckpointPos;
	}


}
