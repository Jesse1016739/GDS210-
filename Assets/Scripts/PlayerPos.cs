using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
	private GameMaster gm;

	private void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		transform.position = gm.LastCheckpointPos;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.CapsLock))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}


}
