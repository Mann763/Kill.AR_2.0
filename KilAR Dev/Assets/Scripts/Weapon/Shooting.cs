using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.XR.ARFoundation;
using System;

public class Shooting : MonoBehaviour
{

    public Animator anim;

    public ARCameraManager fpsCamera;
    public bool Isfiring;

    void Start()
    {
        anim = GetComponent<Animator>();
        fpsCamera = GetComponentInParent<ARCameraManager>();
    }

    void Update()
    {

        if (CrossPlatformInputManager.GetButtonDown("Fire_1"))
        {
            StartFiring();
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire_1"))
        {
            StopFiring();
        }

        if (CrossPlatformInputManager.GetButtonDown("Reload"))
        {
            Reloading();
        }
    }

    void StartFiring()
    {
        Isfiring = true;
        Debug.Log("Down");
        anim.SetBool("Shooting", Isfiring);
    }

    void StopFiring()
    {
        Isfiring = false;
        Debug.Log("UP");
        anim.SetBool("Shooting", Isfiring);
    }

    void Reloading()
    {
        Debug.Log("Reloading");

        anim.SetTrigger("Reloading");
    }
}
