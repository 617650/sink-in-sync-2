using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertParticles : MonoBehaviour
{
    // Particle System Storage Variables
    public ParticleSystem.ShapeModule particleShape;

    // Start is called before the first frame update
    void Start()
    {
        particleShape = GetComponent<ParticleSystem>().shape;

        particleShape.randomDirectionAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Placeholder trigger for color change 
        if (Input.GetKeyDown (KeyCode.Space)){
            particleShape.randomDirectionAmount = 0; 
        }
    }
}
