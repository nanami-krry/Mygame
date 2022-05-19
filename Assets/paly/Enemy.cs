using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float moveSpeed = 4f;
	public int HP = 2;
	public Sprite deadEnemy;
	public Sprite damagedEnemy;
	public float deathSpinMin = -100f;
	public float deathSpinMax = 100f;

	//µ–»Àœ‘ æµƒÕº∆¨
	private SpriteRenderer ren;
	private Transform frontCheck;
	private bool dead = false;


	void Awake()
	{
		ren = transform.Find("body").GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("frontCheck").transform;
	}

	void FixedUpdate()
	{
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);

		foreach (Collider2D c in frontHits)
		{
			if (c.tag == "wall")
			{
				Flip();
				break;
			}
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		if (HP == 1 && damagedEnemy != null)
			ren.sprite = damagedEnemy;
		if (HP <= 0 && !dead)
			Death();
	}

	public void Hurt()
	{
		HP--;
	}

	void Death()
	{
		SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer s in otherRenderers)
		{
			s.enabled = false;
		}
		ren.enabled = true;
		ren.sprite = deadEnemy;
		dead = true;
		Rigidbody2D rd2d = GetComponent<Rigidbody2D>();
		rd2d.freezeRotation = false;
		rd2d.AddTorque(Random.Range(deathSpinMin, deathSpinMax));
		Collider2D[] cols = GetComponents<Collider2D>();
		foreach (Collider2D c in cols)
		{
			c.isTrigger = true;
		}
	}

	public void Flip()
	{
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
