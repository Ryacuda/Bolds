using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
	[SerializeField] private float attraction_range;
	private BoidManager boid_manager;

	// Start is called before the first frame update
	void Start()
	{
		boid_manager = GameObject.Find("BoidManager").GetComponent<BoidManager>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}


}
