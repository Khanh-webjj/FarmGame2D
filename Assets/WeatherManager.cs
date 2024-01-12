using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherState
{
	Clear,
	Rain,
	HeavyRain,RainAndThunder
}
public class WeatherManager : TimeAgent
{
	[Range(0f,1f)] 	[SerializeField] float chanceToChangeWeather = 0.03f;
	WeatherState currWea = WeatherState.Clear;
	[SerializeField] ParticleSystem rain;

	private void Start()
	{
		Init();
		onTimeTick += RandomWeatherChangeCheck;
		UpdateWeather();
	}

	public void RandomWeatherChangeCheck()
	{
		if(UnityEngine.Random.value < chanceToChangeWeather)
		{
			RandomWeatherChange();
		}
	}

	private void RandomWeatherChange()
	{
		WeatherState newWea = (WeatherState)UnityEngine.Random.Range(0, Enum.GetNames(typeof(WeatherState)).Length);
		ChangeWeather(newWea);
	}

	private void ChangeWeather(WeatherState newWea)
	{
		currWea = newWea;
		UpdateWeather();
	}
	public void UpdateWeather()
	{
		switch (currWea)
		{
			case WeatherState.Clear:
				rain.gameObject.SetActive(false);
				break;
			case WeatherState.HeavyRain:
				rain.gameObject.SetActive(true);
				break;
			case WeatherState.Rain:
				rain.gameObject.SetActive(true);
				break;
			case WeatherState.RainAndThunder:
				rain.gameObject.SetActive(true);
				break;
		}
	}
}
