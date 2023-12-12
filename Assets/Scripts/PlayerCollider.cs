using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private VehicleMovement vm_instance;

    // Start is called before the first frame update
    void Start()
    {
        vm_instance = GameObject.Find("Player").GetComponent<VehicleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Ghost"))
        {
            vm_instance.SwitchState(1);
        }
        else if(collision.CompareTag("Wheel"))
        {
			vm_instance.SwitchState(2);
		}
        else if(collision.CompareTag("Gas"))
        {
            vm_instance.SwitchState(3);
        }
	}
}
