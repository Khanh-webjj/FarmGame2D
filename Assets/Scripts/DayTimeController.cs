using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class DayTimeController : MonoBehaviour
{
	const float secondsInDay = 86400f;
	const float phaseLength = 900f;  // 15m chuck of Time
	const float phaseInDay =  96f; // secondsInDay divided by phaseLength


	[SerializeField] Color nightLightColor;
	[SerializeField] AnimationCurve nightTimeCurve;
	[SerializeField] Color dayLightColor = Color.white;

	float time;
	[SerializeField] float timeScale = 60f;
	[SerializeField] float starAtTime = 28800f; // giay
	[SerializeField] float morningTime = 28800f;

	[SerializeField] Light2D globalLight;
	[SerializeField] TextMeshProUGUI daytimetext;

	

	private int days;
	List<TimeAgent> agents;

	private void Awake()
	{
		agents = new List<TimeAgent>();
	}

	private void Start()
	{
		time = starAtTime;
	}
	public  void Subcribe(TimeAgent timeAgent)
	{
		agents.Add(timeAgent);
	}
	public void Unsubcribe(TimeAgent timeAgent)
	{
		agents.Remove(timeAgent);
	}
	float Minutes
	{
		get { return time % 3600f / 60f; }
	}
	float Hours
	{
		get { return time / 3600f; }
	}


	private void Update()
	{
		time += Time.deltaTime * 600f;

		TimeValueCalculation();
		DayLight();
		if (time > secondsInDay)
		{
			NextDay();
		}
		TimeAgents();

		if (Input.GetKeyDown(KeyCode.T))
		{
			SkipTime(hours: 4);
		}
	}

	private void TimeValueCalculation()
	{
		int hh = (int)Hours;
		int mm = (int)Minutes;
		daytimetext.text = hh.ToString("00") + ":" + mm.ToString("00");
	}
	
	private void DayLight()
	{
		float v = nightTimeCurve.Evaluate(Hours);
		Color c = Color.Lerp(dayLightColor, nightLightColor, v);
		globalLight.color = c;
	}



	int oldPhase = -1;
	private void TimeAgents()
	{
		if(oldPhase == -1)
		{
			oldPhase = CalculatePhase();
		}

		int currentPhase = CalculatePhase();

		while(oldPhase < currentPhase)
		{
			oldPhase += 1;
			for (int i = 0; i < agents.Count; i++)
			{
				agents[i].Invoke();
			}
		}
	}

	private int CalculatePhase()
	{
		return (int)(time / phaseLength) +   (int)(days * phaseInDay);
	}

	private void NextDay()
	{

		time -= secondsInDay;
		days += 1;
	}

	public void SkipTime(float seconds = 0, float minute = 0, float hours = 0)
	{
		float timeToSkip = seconds;
		timeToSkip += minute * 60f;
		timeToSkip += hours * 3600f;

		time += timeToSkip;
	}
	public void SkipToMorning()
	{
		float secondsToSkip = 0f;

		if (time > morningTime)
		{
			secondsToSkip += secondsInDay - time + morningTime;
		}
		else
		{
			secondsToSkip += morningTime - time;
		}
		SkipTime(secondsToSkip);
	}
}
