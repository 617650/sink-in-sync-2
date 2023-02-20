using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingFogPrimary : MonoBehaviour
{

    // Color definitions
    private Color SleepyColor = new Color32(107, 90, 214, 40);
    private Color MeditativeColor = new Color32(24, 62, 118, 40);
    private Color RelaxedColor = new Color32(26, 105, 118, 40);
    private Color ActiveColor = new Color32(229, 224, 53, 40);
    private Color AlertColor = new Color32(225, 28, 0, 40);

     public ParticleSystem.MainModule ringFogPrimary;

    // Start is called before the first frame update
    void Start()
    {
        ringFogPrimary = GetComponent<ParticleSystem>().main;

        ringFogPrimary.startColor = SleepyColor; 
    }
    

    // Update is called once per frame
    void Update()
    {
        // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){
            ringFogPrimary.startColor = MeditativeColor; 
        }
    }
}
