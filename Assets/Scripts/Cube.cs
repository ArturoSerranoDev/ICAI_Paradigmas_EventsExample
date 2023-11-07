using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Cube : MonoBehaviour
{
    private float elapsedTime;

    public event Action<Cube> cubeCollidedWithFloor;

    // Start is called before the first frame update
    void Start()
    {
        RandomColorCube();
    }

    private void RandomColorCube()
    {
        GetComponent<Renderer>().material.color = new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I hit a trigger");
        cubeCollidedWithFloor.Invoke(this);
    }

    private void Update()
    {
        if(elapsedTime > 5f)
            Destroy(gameObject);
    }
}
