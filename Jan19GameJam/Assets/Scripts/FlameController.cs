using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class FlameController : MonoBehaviour
{
    [SerializeField] private float startingLightIntensity = 2.0f;
    [SerializeField] private float lightDropInterval = 0.5f;
    [SerializeField] private float fadeSpeed = 1.0f;

    private int uses = 2;

    private float targetLightValue;
    private float targetIntensityValue;
    public float lerpSpeed = 3.0f;

    public PostProcessingProfile p;
    public Light spot;

    private void Start()
    {
        var setting = p.vignette.settings;
        setting.intensity = 0.2f;
        p.vignette.settings = setting;

        targetIntensityValue = 0.2f;
        targetLightValue = 10.0f;
    }

    private void Update()
    {
        var setting = p.vignette.settings;
        setting.intensity = Mathf.Lerp(setting.intensity, targetIntensityValue, Time.deltaTime * lerpSpeed);
        p.vignette.settings = setting;

        spot.intensity = Mathf.Lerp(spot.intensity, targetLightValue, Time.deltaTime * lerpSpeed);
    }

    public bool HasUses()
    {
        return uses > 0;
    }

    public void GainFlame()
    {
        targetIntensityValue -= 0.3f;
        targetLightValue += 5;
        uses += 1;
    }

    public void LoseFlame()
    {
        targetIntensityValue += 0.3f;
        targetLightValue -= 5;
        uses -= 1;
    }
}
