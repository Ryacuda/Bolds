using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class VehicleMovement : MonoBehaviour
{
	[SerializeField] private float turning_speed;       // radians/sec
	[SerializeField] private float max_speed;           // unit/sec
	public float direction;								// radians

	public float speed;                                 // unit/sec

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
        Vector3 desired_direction = Input.mousePosition - new Vector3(Screen.width/2, Screen.height/2, 0f);
		desired_direction.Normalize();

		direction = Mathf.Atan2(desired_direction.y, desired_direction.x);

        transform.position += Time.deltaTime * speed * desired_direction;
	}
}
