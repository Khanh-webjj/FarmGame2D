using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    public int maxVal;
    public int currVal;
    public Stat(int curr, int max)
	{
        maxVal = max;
        currVal = curr;
	}

	internal void Subtract(int amount)
	{
        currVal -= amount;
	}

	internal void Add(int amount)
	{
		currVal += amount;

		if(currVal > maxVal)
		{
			currVal = maxVal;
		}
	}

	internal void SetToMax()
	{
		currVal = maxVal;
	}
}
public class Character : MonoBehaviour, IDamageable
{
    public Stat hp;
	[SerializeField] StatusBar hpBar;
    public Stat stamina;
	[SerializeField] StatusBar staminaBar;

    public bool isDead;
	public bool isExhauted;

	DisableControls disableControls;
	PlayerRepawn playerRepawn;
	private void Awake()
	{
		disableControls = GetComponent<DisableControls>();
		playerRepawn = GetComponent<PlayerRepawn>();
	}
	private void Start()
	{
		UpdateHPBar();
		UpdateStaminaBar();
	}

	private void UpdateStaminaBar()
	{
		staminaBar.Set(stamina.currVal, stamina.maxVal);
	}
	private void UpdateHPBar()
	{
		hpBar.Set(hp.currVal, hp.maxVal);
	}

	public void TakeDamge(int amount)
	{
		if(isDead == true) { return; }
        hp.Subtract(amount);
        if(hp.currVal < 0 )
		{
			Dead();
		}
		UpdateHPBar();
	}

	private void Dead()
	{
		isDead = true;
		disableControls.DisableControl();
		playerRepawn.StartRespawn();
	}


	public void Heal(int amount)
	{
        hp.Add(amount);
		UpdateHPBar();
	}
	public void Fullheal()
	{
		hp.SetToMax();
		UpdateHPBar();
	}

	public void GetTired(int amount)
	{
		stamina.Subtract(amount);
		if(stamina.currVal < 0)
		{
			Exhausted();
		}
		UpdateStaminaBar();
	}

	private void Exhausted()
	{
		isExhauted = true;
		disableControls.DisableControl();
		playerRepawn.StartRespawn();
	}

	public void Rest(int amount)
	{
		stamina.Add(amount);
		UpdateStaminaBar();
	}
	public void FullRest()
	{
		stamina.SetToMax();
		UpdateStaminaBar();
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			TakeDamge(10);
		}
	}

	public void CalculateDamage(ref int damage)
	{
		
	}

	public void ApllyDamage(int damage)
	{
		TakeDamge(damage);
	}

	public void CheckState()
	{
		
	}
}
