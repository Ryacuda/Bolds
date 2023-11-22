using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpriteHandler : MonoBehaviour
{
    [SerializeField] private Vector3 sprite_offset;
    private Transform sprite_transform;

    // Start is called before the first frame update
    void Start()
    {
        sprite_transform = gameObject.transform.Find("sprite");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.forward);
    }
}
