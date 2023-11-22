using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpriteHandler : MonoBehaviour
{
	[SerializeField] private Vector3 sprite_offset;
	private Transform sprite_transform;

	private float sprite_cell_size;
	private int sheet_size;
	private int number_of_cells;
    private int pixel_per_unit;

	// Start is called before the first frame update
	void Start()
	{
		sprite_transform = gameObject.transform.Find("sprite");

		sprite_cell_size = 210;
		sheet_size = 7;
		number_of_cells = 48;
		pixel_per_unit = 32;

		// test offset
		//sprite_transform.position = transform.position + sprite_offset;
	}

	// Update is called once per frame
	void Update()
	{
		// get the current vehicle direction
		float angle = gameObject.GetComponent<VehicleMovement>().direction;

		// index in the sprite sheet
		int i = Mathf.FloorToInt(angle / number_of_cells);

		// position in the sprite sheet
		int x = i % sheet_size;
		int y = Mathf.FloorToInt(i / sheet_size);

		// pivot is center
		x -= 3;
		y -= 3;

		Debug.Log(x);
		Debug.Log(y);

		float mult = sprite_cell_size / pixel_per_unit;
		sprite_offset = new Vector3(x * mult, y * mult);

		sprite_transform.position = transform.position + sprite_offset;
	}
}
