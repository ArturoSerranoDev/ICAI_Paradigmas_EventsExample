using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo : MonoBehaviour
{
    [SerializeField] private CubeSpawner cubeSpawner;
    [SerializeField] private Transform flamingoHead;

    private void OnEnable()
    {
        cubeSpawner.onCubeSpawned += OnCubeSpawned;
    }

    private void OnDisable()
    {
        cubeSpawner.onCubeSpawned -= OnCubeSpawned;
    }
    private void OnCubeSpawned(Cube cube)
    {
        Debug.Log("I have received a cube");
        cube.cubeCollidedWithFloor += OnCubeCollidedWithFloor;
    }

    private void OnCubeCollidedWithFloor(Cube cube)
    {
        flamingoHead.transform.LookAt(cube.transform);

        flamingoHead.GetComponent<Renderer>().material.color = 
            cube.GetComponent<Renderer>().material.color;
        cube.cubeCollidedWithFloor -= OnCubeCollidedWithFloor;
    }
}
