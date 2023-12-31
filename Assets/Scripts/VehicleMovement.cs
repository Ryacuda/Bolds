using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class VehicleMovement : MonoBehaviour
{
	[SerializeField] private float max_turning_angle;       // radians/sec
	[SerializeField] private bool player;

	public float direction;								// radians
	public float speed;                                 // unit/sec

	private int state;
	private Boid boid_instance;

	// Start is called before the first frame update
	void Start()
	{
		boid_instance = GetComponent<Boid>();
	}

	// Update is called once per frame
	void Update()
	{
		if(player)
		{
			PlayerMovement();
		}
		else
		{
			Vector2 new_dir = Vector2.zero;

			new_dir += boid_instance.Rule1();
			new_dir += boid_instance.Rule2();
			new_dir += boid_instance.Rule3();

			ChangeDirection(Mathf.Atan2(new_dir.y, new_dir.x));
		}

		Vector3 desired_direction = new Vector3(Mathf.Cos(direction), Mathf.Sin(direction), 0);
		transform.position += Time.deltaTime * speed * desired_direction;
	}

	private void PlayerMovement()
	{
		Vector3 desired_direction = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0f);

		float angle = Mathf.Atan2(desired_direction.y, desired_direction.x);

		// update the direction
		ChangeDirection(angle);
	}

	public void ChangeDirection(float new_desired_direction)
	{
		// computing the angle difference between the current direction and the desired direction
		float diff = (direction - new_desired_direction);
		
		if(diff > Mathf.PI)
		{
			diff -= Mathf.PI * 2;
		}
		else if (diff < - Mathf.PI)
		{
			diff += Mathf.PI * 2;
		}

		if (Mathf.Abs(diff) < max_turning_angle * Time.deltaTime)
		{
			direction = new_desired_direction;
		}
		else
		{
			// in this case the vehicle can only turn as much as their max turning speed allows it
			if(diff < 0)
			{
				direction += max_turning_angle * Time.deltaTime;
			}
			else
			{
				direction -= max_turning_angle * Time.deltaTime;
			}
		}
	}

	public void SwitchState(int new_state)
	{
		switch(new_state)
		{
			case 1:		// become a ghost
				switch(state)
				{
					case 1:
						break;

					case 2:
						Boid.boid_list.Remove(gameObject.GetComponent<Boid>());
						max_turning_angle /= 2;
						break;

					case 3:
						Boid.boid_list.Remove(gameObject.GetComponent<Boid>());
						speed /= 1.25f;
						break;

					default:
						Boid.boid_list.Remove(gameObject.GetComponent<Boid>());
						break;
				}
				break;

			case 2:     // can turn much faster
				switch (state)
				{
					case 1:
						Boid.boid_list.Add(gameObject.GetComponent<Boid>());
						max_turning_angle *= 2;
						break;

					case 2:
						break;

					case 3:
						speed /= 1.25f;
						max_turning_angle *= 2;
						break;

					default:
						max_turning_angle *= 2;
						break;
				}
				break;

			case 3:
				switch (state)
				{
					case 1:
						Boid.boid_list.Add(gameObject.GetComponent<Boid>());
						speed *= 1.25f;
						break;

					case 2:
						max_turning_angle /= 2;
						speed *= 1.25f;
						break;

					case 3:
						break;

					default:
						speed *= 1.25f;
						break;
				}
				break;

			default : break;
		}

		state = new_state;
	}

}
