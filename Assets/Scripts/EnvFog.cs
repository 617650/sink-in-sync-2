using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvFog : MonoBehaviour
{

    // Color definitions
    private Color SleepyColor = new Color32(77, 60, 152, 225);
    private Color MeditativeColor = new Color32(24, 62, 118, 225);
    private Color RelaxedColor = new Color32(26, 105, 118, 225);
    private Color ActiveColor = new Color32(229, 224, 53, 225);
    private Color AlertColor = new Color32(225, 28, 0, 225);

    // Material Storage Variables
    public ParticleSystem.MainModule envFog;
    
    // Start is called before the first frame update
    void Start()
    {
        envFog = GetComponent<ParticleSystem>().main;

        envFog.startColor = SleepyColor; 
    }

    // Update is called once per frame
    void Update()
    {
        // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){
            envFog.startColor = MeditativeColor; 
        }
    }
}
