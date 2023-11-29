using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
	[SerializeField] private float attraction_range;
	private BoidManager boid_manager;
	private VehicleMovement vm_instance;

	// Start is called before the first frame update
	void Start()
	{
		boid_manager = GameObject.Find("BoidManager").GetComponent<BoidManager>();
        vm_instance = gameObject.GetComponent<VehicleMovement>();

		boid_manager.boid_list.Add(this);
    }

	// Update is called once per frame
	void Update()
	{
		
	}

	private void Rule1()
	{
		Vector2 p = new Vector2(transform.position.x, transform.position.y);

        // center of mass without self
        Vector2 others = boid_manager.center_of_mass - p / boid_manager.boid_list.Count;

		Vector2 dir = others - p;

		vm_instance.ChangeDirection(dir);
	}
}
