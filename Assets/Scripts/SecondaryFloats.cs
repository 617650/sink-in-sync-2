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

    public TestData testData;
    public ColorPresets colorPresets; 

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start by moving up OR down : randomizer
    int randomInt;

    // Data Storage Variables
    int randomFrequency;
    int randomType;

    // Material Storage Variables
    public Material fresnelPulse; // refers to the shader on the material
    private float lerpCount;
    private Color32 fresnelColor;
    private Color32 nextColor; 

    // Frequency Storage Variable
    private float pulseSpeed;

    // Placeholder for input data
    public float dominateBand;

    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        randomInt = Random.Range(0,2);

        fresnelPulse = GetComponent<MeshRenderer>().sharedMaterial;
        fresnelPulse.SetColor("_FresnelColor", colorPresets.floatColors[2]);
        fresnelPulse.SetColor("_NextColor", colorPresets.floatColors[2]);
        
        fresnelPulse.SetFloat("_LerpCount", 0f);
        fresnelPulse.SetFloat("_PulseSpeed", 3f);
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

        // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){

            fresnelPulse.SetFloat("_LerpCount", 0f);
            lerpCount = fresnelPulse.GetFloat("_LerpCount");

            // Get random color to change to
            randomType = testData.randomSecondaryType;
            nextColor = colorPresets.floatColors[randomType];

            StartCoroutine(UpdateColor(nextColor));

            StartCoroutine(SetCurrentState());
        }

        // Placeholder trigger for pulse speed change
        pulseSpeed = 3f;
        fresnelPulse.SetFloat("_PulseSpeed", pulseSpeed);

    }

    IEnumerator UpdateColor(Color32 nextColor){
        fresnelPulse.SetColor("_NextColor", nextColor);

        for (int i = 0; i < 100; i++){
            lerpCount ++;
            fresnelPulse.SetFloat("_LerpCount", lerpCount);
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator SetCurrentState(){
        yield return new WaitForSeconds(2f);

        // Set _FresnelColor to be the same as _NextColor
        fresnelColor = fresnelPulse.GetColor("_NextColor");
        fresnelPulse.SetColor("_FresnelColor", fresnelColor);

        // Reset _LerpCount
        fresnelPulse.SetFloat("_LerpCount", 0f);
        lerpCount = fresnelPulse.GetFloat("_LerpCount");
    }

}
