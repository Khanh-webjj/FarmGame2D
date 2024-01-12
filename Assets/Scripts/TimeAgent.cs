using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{

	public Action onTimeTick;
	private void Start()
	{
		Init();
	}
	public void Init() {GameManager.Instance.timeController.Subcribe(this); }

	public void Invoke()
	{
		onTimeTick?.Invoke();
	}


	private void OnDestroy()
	{
		GameManager.Instance.timeController.Unsubcribe(this);
	}
}

