using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Volume : MonoBehaviour
{
    private PostProcessVolume volume;
    private ColorGrading color;
    [SerializeField] private WeatherHandler weatherHandler;
    private int weather = 0;
    [SerializeField] private GameObject invierno;
    [SerializeField] private GameObject infierno;
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out color);
        StartCoroutine(WaitForWeather());
        
    }

    // Update is called once per frame
    void Update()
    {
        Valoracion();
    }

    private void Valoracion()
    {
        if (weatherHandler.weatherData.temp > 20 && weather < 1000)
        {
            Aumento();
        }
        if (weatherHandler.weatherData.temp < 20 && weather > -1000)
        {
            Disminucion();
        }
    }

    private void Aumento()
    {
        weather++;
        //color.saturation.value += 10f * Time.deltaTime;
        //color.contrast.value += 10f * Time.deltaTime;
        color.temperature.value += 30f * Time.deltaTime;
    }
    private void Disminucion()
    {
        weather--;
        //color.saturation.value -= 10f * Time.deltaTime;
        //color.contrast.value -= 10f * Time.deltaTime;
        color.temperature.value -= 30f * Time.deltaTime;
    }

    private IEnumerator WaitForWeather()
    {
        yield return new WaitForSeconds(2f);
        ScenarioChange();
    }

    private void ScenarioChange()
    {
        if (weatherHandler.weatherData.temp > 20)
        { 
            invierno.SetActive(false);
            infierno.SetActive(true);
        }
        if (weatherHandler.weatherData.temp < 20)
        {
            infierno.SetActive(false);
            invierno.SetActive(true);
        }
    }
}
