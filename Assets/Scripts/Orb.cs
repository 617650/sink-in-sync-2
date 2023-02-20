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

    // Data Script
    public TestData testData;
    public ColorPresets colorPresets; 

    // Data Storage Variables
    int randomFrequency;
    int randomType;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Visual Effects Graph 
    [SerializeField]
    private VisualEffect orbEffect;

    [SerializeField, Range(1f,5f)]
    private float noiseReduction = 3f;

    // Lerp Storage Variables
    private float lerpStep = 0.01f;
    private Vector4 lerpedColor; 
    private Vector4 currentColor;
    private Vector4 nextColor; 

    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;

        // Set VFX properties
        orbEffect.SetVector4("OrbColor", colorPresets.orbColors[4] * 0.002f);
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

            //currentColor = orbEffect.GetVector4("OrbColor");
            randomType = testData.randomDominateType;

            if (randomType - 1 == -1){
                currentColor = colorPresets.orbColors[4];
            }else{
                currentColor = colorPresets.orbColors[randomType-1];
            }
            nextColor = colorPresets.orbColors[randomType];

            // Debug.Log("currentColor" + currentColor);
            // Debug.Log("nextColor" + nextColor);

            StartCoroutine(UpdateColor(currentColor, nextColor));
        }

    }

    IEnumerator UpdateColor(Vector4 currentColor, Vector4 nextColor){
        for (int i = 0; i < 100; i++){
            
            lerpedColor = Vector4.Lerp(currentColor, nextColor, i*lerpStep);
            
            orbEffect.SetVector4("OrbColor", lerpedColor * 0.002f);

            yield return new WaitForSeconds(0.02f);
        }
    }
}
