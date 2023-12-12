using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
	static public List<Boid> boid_list = new List<Boid>();

	[SerializeField] private float attraction_range;
	[SerializeField] private float repulsion_range;
	[SerializeField] private float alignment_range;

	private VehicleMovement vm_instance;

	// Start is called before the first frame update
	void Start()
	{
		boid_list.Add(this);
		vm_instance = GetComponent<VehicleMovement>();
    }

	// Update is called once per frame
	void Update()
	{
		
	}

	// attraction rule
	public Vector2 Rule1()
	{
		// center of mass without self
		Vector2 others = CenterOfMassOthers();

		Vector2 dir = others - new Vector2(transform.position.x, transform.position.y);
		return dir;
	}

	// repulsion rule
	public Vector2 Rule2()
	{
		// center of mass without self
		Vector2 c = Vector2.zero;

		foreach (Boid boid in boid_list)
		{
			// ignore the boid if self or too far
			if (boid.Equals(this)
			  || Vector2.Distance(boid.transform.position, transform.position) > repulsion_range)
			{
				continue;
			}

			c += new Vector2(transform.position.x - boid.transform.position.x, transform.position.y - boid.transform.position.y);
		}

		return c;
	}

	// alignment rule
	public Vector2 Rule3()
	{
		// center of mass without self
		Vector2 average_velocity = Vector2.zero;

		int boid_count = 0;
		foreach (Boid boid in boid_list)
		{
			// ignore the boid if self or too far
			if (boid.Equals(this)
			  || Vector2.Distance(boid.transform.position, transform.position) > alignment_range)
			{
				continue;
			}

			average_velocity += new Vector2( Mathf.Cos( vm_instance.direction), Mathf.Sin(vm_instance.direction) );
			boid_count++;
		}

		if(boid_count > 0)
		{
			average_velocity /= boid_count;
		}

		return average_velocity;
	}

	private Vector2 CenterOfMassOthers()
	{
		// clear the center of mass
		Vector2 center_of_mass = Vector2.zero;

		int boid_count = 0;
		// compute the average of the positions
		foreach (Boid boid in boid_list)
		{
			// ignore the boid if self or too far
			if(boid.Equals(this)
			  || Vector2.Distance(boid.transform.position, transform.position) > attraction_range )
			{
				continue;
			}

			center_of_mass += new Vector2(boid.transform.position.x, boid.transform.position.y);
			boid_count++;
		}

		center_of_mass /= boid_count;

		return center_of_mass;
	}
}
