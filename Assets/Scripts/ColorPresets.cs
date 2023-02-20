using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPresets : MonoBehaviour
{

    // Floats
    public Color32[] floatColors = new Color32[] { 
        new Color32(217, 181, 53, 0), // Alert
        new Color32(122, 143, 86, 0), // Active
        new Color32(26, 105, 118, 0), // Relaxed
        new Color32(24, 62, 118, 0), // Meditative
        new Color32(22, 19, 118, 0) // Sleepy
    };

    // Orb
    public Vector4[] orbColors = new Vector4[] { 
        new Vector4(217, 181, 53, 0), // Alert
        new Vector4(122, 143, 86, 0), // Active
        new Vector4(26, 105, 118, 0), // Relaxed
        new Vector4(24, 62, 118, 0), // Meditative
        new Vector4(22, 19, 118, 0) // Sleepy
    }; 

    // Trail
    public Vector4[] trailColors = new Vector4[] { 
        new Vector4(217, 181, 53, 0), // Alert
        new Vector4(122, 143, 86, 0), // Active
        new Vector4(26, 105, 118, 0), // Relaxed
        new Vector4(24, 62, 118, 0), // Meditative
        new Vector4(18, 14, 166, 0) // Sleepy
    };

    // EnvFog
    public Color[] envFogColors = new Color[] { 
        new Color32(217, 181, 53, 255), // Alert
        new Color32(122, 143, 86, 255), // Active
        new Color32(26, 105, 118, 225), // Relaxed
        new Color32(24, 62, 118, 225), // Meditative
        new Color32(77, 60, 152, 225) // Sleepy
    };

    // Particles

}
