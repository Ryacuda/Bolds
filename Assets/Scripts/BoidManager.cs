using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
	private static List<Boid> BoidList = new List<Boid>();

	private Vector2 center_of_mass;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		UpdateCenterOfMass();
	}

	private void UpdateCenterOfMass()
	{
		center_of_mass = Vector2.zero;

		foreach(Boid boid in BoidList)
		{
			center_of_mass += new Vector2(boid.transform.position.x, boid.transform.position.y);
		}

		center_of_mass /= BoidList.Count;
	}
}
