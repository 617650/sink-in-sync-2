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

    // Material Storage Variables
    public Material fresnelPulse; // refers to the shader on the material
    private float lerpCount;
    private Color32 fresnelColor;

    // Frequency Storage Variable
    private float pulseSpeed;

    // Placeholder for input data
    public float dominateBand;

    // Color definitions
    private Color32 SleepyColor = new Color32(22, 19, 118, 0);
    private Color32 MeditativeColor = new Color32(24, 62, 118, 0);
    private Color32 RelaxedColor = new Color32(26, 105, 118, 0);
    private Color32 ActiveColor = new Color32(229, 224, 53, 0);
    private Color32 AlertColor = new Color32(225, 28, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        randomInt = Random.Range(0,2);

        fresnelPulse = GetComponent<MeshRenderer>().sharedMaterial;
        fresnelPulse.SetColor("_FresnelColor", RelaxedColor);
        fresnelPulse.SetColor("_NextColor", RelaxedColor);
        
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
        if (Input.GetKeyDown (KeyCode.A)){

            fresnelPulse.SetFloat("_LerpCount", 0f);
            lerpCount = fresnelPulse.GetFloat("_LerpCount");

            if (fresnelPulse.GetColor("_NextColor").Equals(RelaxedColor)) {
                StartCoroutine(Update32());
            }else{
                StartCoroutine(Update23());
            }

            StartCoroutine(SetCurrentState());
        }

        // Placeholder trigger for pulse speed change
        pulseSpeed = 3f;
        fresnelPulse.SetFloat("_PulseSpeed", pulseSpeed);

    }

    IEnumerator Update32(){
        fresnelPulse.SetColor("_NextColor", ActiveColor);
                
        // Increase _LerpCount
        for (int i = 0; i < 100; i++){
            lerpCount ++;
            fresnelPulse.SetFloat("_LerpCount", lerpCount);
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator Update23(){
        fresnelPulse.SetColor("_NextColor", RelaxedColor);

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
