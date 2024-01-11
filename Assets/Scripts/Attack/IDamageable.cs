using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
	public void CalculateDamage(ref int damage);
	public void ApllyDamage(int damage);
	public void CheckState();
}
