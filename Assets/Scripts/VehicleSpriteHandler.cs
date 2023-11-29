using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class VehicleSpriteHandler : MonoBehaviour
{
	[SerializeField] private Vector3 sprite_offset;
	private Transform sprite_transform;
	private Transform collider_transform;

	private float sprite_cell_size;
	private int sheet_size;
	private int number_of_cells;
    private int pixel_per_unit;

	// Start is called before the first frame update
	void Start()
	{
		sprite_transform = gameObject.transform.Find("sprite");
		collider_transform = gameObject.transform.Find("collider");
        sheet_size = 7;
        sprite_cell_size = ((int)sprite_transform.GetComponent<SpriteRenderer>().sprite.rect.height)/sheet_size;
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
		int i = Mathf.FloorToInt( number_of_cells * (- (angle > 0 ? -2f * Mathf.PI + angle : angle)) / (2f * Mathf.PI)) ;

		// position in the sprite sheet
		int x = (i % sheet_size) - 3;
		int y =  Mathf.FloorToInt( (i - x) / sheet_size ) - 3;

		float offset_unit = sprite_cell_size / pixel_per_unit;

		sprite_offset = offset_unit * new Vector3(-x, y);

		// apply computed offset
		sprite_transform.position = transform.position + sprite_offset;
		collider_transform.rotation = Quaternion.Euler(0, 0, 180f * angle / Mathf.PI);
	}
}
