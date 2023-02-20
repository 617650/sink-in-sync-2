using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SecondaryTrail : MonoBehaviour
{

    // Visual Effects Graph 
    [SerializeField]
    private VisualEffect secondaryTrail;

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
        // Set VFX properties
        secondaryTrail.SetVector4("Color", MeditativeColor * 0.005f);
    }

    // Update is called once per frame
    void Update()
    {
         // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){
            StartCoroutine(Update45());
        }
    }

    IEnumerator Update45(){
        for (int i = 0; i < 100; i++){
            
            lerpedColor = Vector4.Lerp(MeditativeColor, SleepyColor, i*lerpStep);
            secondaryTrail.SetVector4("Color", lerpedColor * 0.005f);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
