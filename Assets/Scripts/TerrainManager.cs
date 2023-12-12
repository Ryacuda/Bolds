using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
	private Transform player_transform;
	// Start is called before the first frame update
	void Start()
	{
		player_transform = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	void Update()
	{
		// move the tile up/down if player is too far vertically
		if(gameObject.transform.position.x > player_transform.position.x + 48)
		{
			gameObject.transform.Translate(new Vector3(-80, 0, 0));
		}
		else if (gameObject.transform.position.x < player_transform.position.x - 48)
		{
			gameObject.transform.Translate(new Vector3(80, 0, 0));
		}

		//move tile sideway if player is too far horizontally
		if (gameObject.transform.position.y > player_transform.position.y + 21.250)
		{
			gameObject.transform.Translate(new Vector3(0, -42.5f, 0));
		}
		else if (gameObject.transform.position.y < player_transform.position.y - 21.250)
		{
			gameObject.transform.Translate(new Vector3(0, 42.5f, 0));
		}
	}
}
