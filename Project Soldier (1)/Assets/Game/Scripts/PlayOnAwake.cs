using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnAwake : MonoBehaviour
{

    private AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        audio.Play();
    }
}
	
