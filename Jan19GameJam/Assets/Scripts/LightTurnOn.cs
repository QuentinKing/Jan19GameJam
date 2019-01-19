using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTurnOn : MonoBehaviour
{
    public Light controlledLight;

    [SerializeField] private float lightOnIntensity = 1.0f;
    [SerializeField] private float turnOnSpeed = 1.0f;

    private bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        active = true;
    }

    void Update()
    {
        if (active)
        {
            controlledLight.intensity = Mathf.Lerp(controlledLight.intensity, lightOnIntensity, Time.deltaTime * turnOnSpeed);
        }
    }
}
