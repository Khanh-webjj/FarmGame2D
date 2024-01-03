using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    float time;

    [SerializeField] Text text;
    [SerializeField] Text textDay;
    [SerializeField] float timeScale = 60f;
    [SerializeField] Light2D globalLight;
    private int days;

    float Hours
    {
        get { return time / 3600f; }
    }
    float Minutes {
        get { return (time % 3600f) / 60f; }
    }
    private void Update()
    {
        time += Time.deltaTime * timeScale;
        int hours = (int)Hours;
        int minutes = (int)Minutes;
        text.text = hours.ToString("00") + ":" + minutes.ToString("00");
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if (time > secondsInDay)
        {
            NextDay();
        }
        textDay.text = "Day: "+ days.ToString("00");
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
