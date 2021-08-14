using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private float _groundLevelToRespawn;
    [SerializeField] private float spawnAreaInRange;

    [SerializeField] private Transform _respawnArea;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Obstacle>() != null)
        {
            Respawn();
        }
    }

    void Update()
    {
        if (transform.position.y < _groundLevelToRespawn)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = new Vector3(Random.Range(-spawnAreaInRange, spawnAreaInRange), _respawnArea.position.y, _respawnArea.position.z);
    }


}
