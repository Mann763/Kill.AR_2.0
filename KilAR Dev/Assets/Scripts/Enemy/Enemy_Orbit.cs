using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Orbit : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Rotate();
    }

    //Orbiting Logic
    void Rotate()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
