using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    [SerializeField] private float startingLightIntensity = 2.0f;
    [SerializeField] private float lightDropInterval = 0.5f;
    [SerializeField] private float fadeSpeed = 1.0f;

    private float targetLightValue;

    public Light pointLight;

    private void Start()
    {
        if (pointLight != null)
        {
            pointLight.intensity = startingLightIntensity;
        }

        lightDropInterval = Mathf.Min(startingLightIntensity, lightDropInterval);
        targetLightValue = startingLightIntensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BadStuff")
        {
            targetLightValue = targetLightValue - lightDropInterval;
        }

        if (other.tag == "GoodStuff")
        {
            targetLightValue = targetLightValue + lightDropInterval;
        }

        if (targetLightValue <= 0.0f)
        {
            // game over or whatever lol
            Debug.LogError("youre dead");
        }
    }

    private void Update()
    {
        pointLight.intensity = Mathf.Lerp(pointLight.intensity, targetLightValue, Time.deltaTime * fadeSpeed);
    }
}
