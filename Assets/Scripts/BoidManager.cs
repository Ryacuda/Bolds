using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
	public List<Boid> boid_list;

	public Vector2 center_of_mass;

	// Start is called before the first frame update
	void Start()
	{
		boid_list = new List<Boid>();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateCenterOfMass();
	}

	private void UpdateCenterOfMass()
	{
		// clear the center of mass
		center_of_mass = Vector2.zero;

		foreach(Boid boid in boid_list)
		{
			center_of_mass += new Vector2(boid.transform.position.x, boid.transform.position.y);
		}

		//Debug.Log(boid_list.Count);

		center_of_mass /= boid_list.Count;
	}
}
