using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Spawner : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject Projectile;

    public float FireRate; 
    
    float currentTime;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = FireRate;
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if (currentTime >= FireRate)
        {
            SpawnProjectile();
            currentTime = 0f;
        }        
    }

    void SpawnProjectile()
    {
        GameObject vfx;

        if(firePoint != null)
        {
            vfx = Instantiate(Projectile, firePoint.transform.position, Quaternion.identity);
            anim.SetTrigger("Fire");
        }
        else
        {
            Debug.Log("No Fire Point Assigned");
        }
    }
}
