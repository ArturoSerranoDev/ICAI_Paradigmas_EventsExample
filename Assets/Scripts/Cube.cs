using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Cube : MonoBehaviour
{
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I hit a collider");
    }

    private void Update()
    {
        if(elapsedTime > 5f)
            Destroy(gameObject);
    }
}
