using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public Slider BGM;

    public void onchangevalue()
    {
        bool onoff = gameObject.GetComponent<Toggle>().isOn;
        if (onoff)
        {
            BGM.interactable = true;
            BGM.value = 1;
        }
        else
        {
            BGM.interactable = false;
            BGM.value = -35;
        }
    }
}
