using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteSound : MonoBehaviour
{
    AudioSource audio1;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            if (audio1.mute)
                audio1.mute = false;
            else
                audio1.mute = true;
    }
}