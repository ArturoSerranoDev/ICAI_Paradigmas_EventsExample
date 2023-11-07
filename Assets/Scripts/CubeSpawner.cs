using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    
    [SerializeField] private Vector2 xSpawnLimits;
    [SerializeField] private Vector2 zSpawnLimits;
    
    [SerializeField] private bool isSpawning = true;

    public event Action<Cube> onCubeSpawned;

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }
    private IEnumerator SpawnCubes()
    {
        while (isSpawning)
        {
            SpawnCube();

            yield return new WaitForSeconds(1f);
        }
    }
    private void SpawnCube()
    {
        Vector3 randomSpawnPoint = new Vector3(
            Random.Range(xSpawnLimits.x, xSpawnLimits.y),
            15f,
            Random.Range(zSpawnLimits.x, zSpawnLimits.y));

        GameObject newCube = Instantiate(cubePrefab, randomSpawnPoint, Quaternion.identity);

        onCubeSpawned.Invoke(newCube.GetComponent<Cube>());

        // Add some rotation to cube
        newCube.GetComponent<Rigidbody>().AddTorque(Vector3.one + 10f * randomSpawnPoint, ForceMode.Impulse);
    }

    private void OnCubeCollided(Collider other)
    {

    }
}
