using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
   public static BGM Instance{ set; get; }
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
