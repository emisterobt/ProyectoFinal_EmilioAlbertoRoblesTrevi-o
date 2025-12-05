using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Volume : MonoBehaviour
{
    private PostProcessVolume volume;
    private ColorGrading color;
    [SerializeField] private WeatherHandler weatherHandler;
    private int weather = 0;
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out color);
    }

    // Update is called once per frame
    void Update()
    {
        if (weatherHandler.weatherData.temp > 20 && weather < 500)
        {
            Aumento();
        }
        if (weatherHandler.weatherData.temp < 20 && weather > -500)
        {
            Disminucion();
        }
    }

    private void Aumento()
    {
        weather++;
        color.saturation.value += 10f * Time.deltaTime;
        color.contrast.value += 10f * Time.deltaTime;
    }
    private void Disminucion()
    {
        weather--;
        color.saturation.value -= 10f * Time.deltaTime;
        color.contrast.value -= 10f * Time.deltaTime;
    }
}
