using UnityEngine;
using SimpleJSON;
using System.Collections;
using UnityEngine.Networking;

public class WeatherHandler : MonoBehaviour
{
    [SerializeField] private float lon;
    [SerializeField] private float lat;
    [SerializeField] public WatherData weatherData;
    private string url;

    private string apiKey = "b1cc50df2d8e1fe2a28c2ca8448a1027";
    private string jsonRAW;
    void Start()
    {

        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=minutely,hourly,daily&appid={apiKey}&units=metric";
        StartCoroutine(UpdateWeather());
    }

    IEnumerator UpdateWeather()
    {
        UnityWebRequest request = new UnityWebRequest(url);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            jsonRAW = request.downloadHandler.text;
            Debug.Log(jsonRAW);

            ReadJson();
        }
    }

    private void ReadJson()
    {
        var weatherJson = JSON.Parse(jsonRAW); //Se almacena al json

        weatherData.timeZone = weatherJson["timezone"].Value;
        weatherData.temp = float.Parse(weatherJson["current"]["temp"].Value);
        weatherData.weatherDescription = weatherJson["current"]["weather"][0]["description"];


    }
}
