using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    Transform player;
	[SerializeField] float speed;
	[SerializeField] Vector2 attackSize = Vector2.one;
	[SerializeField] int damage = 5;
	[SerializeField] float timeToAttack = 2f;
	float attackTimer;
	private void Start()
	{
		player = GameManager.Instance.player.transform;
		attackTimer = Random.Range(0, timeToAttack);
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(
			transform.position,
			player.position,
			speed * Time.deltaTime);
		Attack();
	}

	private void Attack()
	{
		attackTimer -= Time.deltaTime;
		if(attackTimer > 0f)
		{
			return;
		}
		attackTimer = timeToAttack;
		Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, attackSize, 0f);

		for (int i = 0; i < targets.Length; i++)
		{
			DamageableObject character = targets[i].GetComponent<DamageableObject>();
			if (character != null)
			{
				character.TakeDamage(damage);
			}
		}
	}
}
