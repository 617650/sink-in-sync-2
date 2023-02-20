using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DominateTrail : MonoBehaviour
{
    // Visual Effects Graph 
    [SerializeField]
    private VisualEffect dominateTrail;

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
        dominateTrail.SetVector4("Color", colorPresets.trailColors[4] * 0.005f);
    }

    // Update is called once per frame
    void Update()
    {
        // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){
            
            //urrentColor = dominateTrail.GetVector4("Color");
            randomType = testData.randomDominateType;

            if (randomType - 1 < 0){
                currentColor = colorPresets.trailColors[4];
            }else{
                currentColor = colorPresets.trailColors[randomType-1];
            }
            nextColor = colorPresets.trailColors[randomType];

            StartCoroutine(UpdateColor(currentColor, nextColor));
        }
    }

    IEnumerator UpdateColor(Vector4 currentColor, Vector4 nextColor){
        for (int i = 0; i < 100; i++){
            
            lerpedColor = Vector4.Lerp(currentColor, nextColor, i*lerpStep);
            
            dominateTrail.SetVector4("Color", lerpedColor * 0.005f);

            yield return new WaitForSeconds(0.02f);
        }
    }
}
