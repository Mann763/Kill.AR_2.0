using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Controller : MonoBehaviour
{
    AudioSource au;

    public AudioClip Spawning_enemy;

    

    // Start is called before the first frame update
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        au.PlayOneShot(Spawning_enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
