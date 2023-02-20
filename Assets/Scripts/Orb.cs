using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Orb : MonoBehaviour
{
    // User Inputs
    public float amplitudeY = 10f;
    public float frequencyY = 0.5f;
    public float degreesPerSecond = 3.0f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Visual Effects Graph 
    [SerializeField]
    private VisualEffect orbEffect;

    [SerializeField, Range(1f,5f)]
    private float noiseReduction = 3f;

    // Color Scheme
    private Vector4 SleepyColor = new Vector4(22, 19, 118, 0);
    private Vector4 MeditativeColor = new Vector4(24, 62, 118, 0);
    private Vector4 RelaxedColor = new Vector4(26, 105, 118, 0);
    private Vector4 ActiveColor = new Vector4(229, 224, 53, 0);
    private Vector4 AlertColor = new Vector4(225, 28, 0, 0);

    // Lerp Storage Variables
    private float lerpStep = 0.01f;
    private Vector4 lerpedColor; 

    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;

        // Set VFX properties
        orbEffect.SetVector4("OrbColor", SleepyColor * 0.002f);
        orbEffect.SetFloat("NoiseReduction", noiseReduction);

    }

    // Update is called once per frame
    void Update()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequencyY) * amplitudeY;
        transform.position = tempPos;

        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){
            StartCoroutine(Update54());
        }

    }

    IEnumerator Update54(){
        for (int i = 0; i < 100; i++){
            
            lerpedColor = Vector4.Lerp(SleepyColor, MeditativeColor, i*lerpStep);
            
            orbEffect.SetVector4("OrbColor", lerpedColor * 0.002f);

            yield return new WaitForSeconds(0.02f);
        }
    }
}
