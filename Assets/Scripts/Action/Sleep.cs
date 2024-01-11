using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
	DisableControls disableControls;
	Character character;
	DayTimeController dayTime;
	private void Awake()
	{
		disableControls = GetComponent<DisableControls>();
		character = GetComponent<Character>();
		dayTime = GameManager.Instance.timeController;
	}
	internal void DoSleep()
	{
		StartCoroutine(SleepRoutine());
	}
	IEnumerator SleepRoutine()
	{
		ScreenTint sc =	GameManager.Instance.screenTint;

		disableControls.DisableControl();

		sc.Tint();
		yield return new WaitForSeconds(2f);

		character.Fullheal();
		character.FullRest();
		dayTime.SkipToMorning();


		sc.UnTint();
		yield return new WaitForSeconds(2f);
		disableControls.EnableControl();

		yield return null;
	}
}
