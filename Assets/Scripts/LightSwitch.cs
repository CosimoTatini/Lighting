
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public string lightLayerName = "Light";
    public string playerLayerName = "Player";
    private List<Light> lights;
    private int lightTargetLayer;
    private int playerTargetLayer;


    private void Start()
    {
        lightTargetLayer = LayerMask.NameToLayer(lightLayerName);
        playerTargetLayer= LayerMask.NameToLayer(playerLayerName);

        lights=  FindObjectsByType<Light>(FindObjectsSortMode.None).Where( light => light.gameObject.layer == lightTargetLayer ).ToList();
        SetLightState(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == playerTargetLayer)
        {
            SetLightState(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerTargetLayer)
        {
            SetLightState(false);
        }
    }

    private void SetLightState(bool v)
    {
        if (lights == null || lights.Count == 0) return;

        foreach (Light light in lights)
        {
            if(light!=null)
            {
                light.enabled = v;
            }
        }
    }

   

}




