using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
	IDamageable damageable;

	internal void TakeDamage(int damage)
	{
		if(damageable == null)
		{
			damageable = GetComponent<IDamageable>();
		}

		damageable.CalculateDamage(ref damage);
		damageable.ApllyDamage(damage);
		GameManager.Instance.messageSystem.PostMessage(transform.position, damage.ToString());
		damageable.CheckState();
	}
}
