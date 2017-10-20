using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	/// <summary>
	/// 子弹速度
	/// </summary>
	public float speed = 10;


	/// <summary>
	/// 伤害能力
	/// </summary>
	public float attack = 100;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Destroy(this.gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
		//子弹向前运动
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider col)
	{
		//碰撞到 Boss 或者 怪物 
		if (col.tag == Tags.soulBoss || col.tag == Tags.soulMonster)
		{
			col.GetComponent<ATKAndDamage>().TakeDamage(attack);
		}
		
	}
}
