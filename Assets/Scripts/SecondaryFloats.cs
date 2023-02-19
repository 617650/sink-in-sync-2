using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryFloats : MonoBehaviour
{

    // User Inputs
    public float amplitudeY = 10f;
    public float amplitudeX = 5f;
    public float frequencyY = 0.5f;
    public float frequencyX = 0.2f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start by moving up OR down : randomizer
    int randomInt;


    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;

        randomInt = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;

        if (randomInt == 1) {
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequencyY) * amplitudeY;
            tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * frequencyX) * amplitudeX;
        } else{
            tempPos.y -= Mathf.Sin(Time.fixedTime * Mathf.PI * frequencyY) * amplitudeY;
            tempPos.x -= Mathf.Sin(Time.fixedTime * Mathf.PI * frequencyX) * amplitudeX;
        }

        transform.position = tempPos;
    }
}
