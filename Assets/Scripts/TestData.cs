using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{

    public int randomFrequency;
    public int randomDominateType;
    public int randomSecondaryType;

    private int i = -1;
    private int j = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space)){
            i++;
            j++;
            Debug.Log(i);
            randomDominateType = i % 5;
            randomSecondaryType = j % 5;
        }
    }
}
