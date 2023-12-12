using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> bonuses;
    [SerializeField] float time_between_spawns;
    [SerializeField] float spawn_range;
    
    private Transform player_transform;

    // Start is called before the first frame update
    void Start()
    {
        player_transform = GameObject.Find("Player").transform;

        InvokeRepeating("SpawnRandomBonus", 2, time_between_spawns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomBonus()
    {
        int i = Random.Range(0, bonuses.Count);
        float angle = Random.Range(0, 2 * Mathf.PI);

        Instantiate(bonuses[i], player_transform.position + spawn_range * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0), Quaternion.identity);
    }
}
