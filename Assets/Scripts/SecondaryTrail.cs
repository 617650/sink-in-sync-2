using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SecondaryTrail : MonoBehaviour
{

    // Visual Effects Graph 
    [SerializeField]
    private VisualEffect secondaryTrail;

    // Data Script
    public TestData testData;
    public ColorPresets colorPresets; 

    // Data Storage Variables
    int randomFrequency;
    int randomType;

    // Lerp Storage Variables
    private float lerpStep = 0.01f;
    private Vector4 lerpedColor; 
    private Vector4 currentColor;
    private Vector4 nextColor; 

    // Start is called before the first frame update
    void Start()
    {
        // Set VFX properties
        secondaryTrail.SetVector4("Color", colorPresets.trailColors[3] * 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
         // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){

            currentColor = secondaryTrail.GetVector4("Color");
            randomType = testData.randomSecondaryType;
            nextColor = colorPresets.trailColors[randomType];

            StartCoroutine(UpdateColor(currentColor, nextColor));
        }
    }

    IEnumerator UpdateColor(Vector4 currentColor, Vector4 nextColor){
        for (int i = 0; i < 100; i++){
            
            lerpedColor = Vector4.Lerp(currentColor, nextColor, i*lerpStep);

            secondaryTrail.SetVector4("Color", lerpedColor * 0.001f);

            yield return new WaitForSeconds(0.02f);
        }
    }
}
