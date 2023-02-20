using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvFog : MonoBehaviour
{
    // Data Script
    public TestData testData;
    public ColorPresets colorPresets; 

    // Data Storage Variables
    int randomFrequency;
    int randomType;
    private Color nextColor; 

    // Material Storage Variables
    public ParticleSystem.MainModule envFog;
    
    // Start is called before the first frame update
    void Start()
    {
        envFog = GetComponent<ParticleSystem>().main;

        envFog.startColor = colorPresets.envFogColors[4]; 
    }

    // Update is called once per frame
    void Update()
    {
        // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){

            randomType = testData.randomDominateType;
            nextColor = colorPresets.envFogColors[randomType];

            envFog.startColor = nextColor; 
        }
    }
}
