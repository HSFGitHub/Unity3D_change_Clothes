using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : MonoBehaviour {


	/// <summary>
	/// 子弹位置
	/// </summary>
	public Transform bulletPos;

	/// <summary>
	/// 子弹物体
	/// </summary>
	public GameObject bulletPrefab;

	public float attack = 100;

	/// <summary>
	/// 枪攻击方法
	/// </summary>
	public void shot(){
		GameObject bullet = GameObject.Instantiate(bulletPrefab,bulletPos.position,transform.root.rotation) as GameObject;
		bullet.GetComponent<Bullet>().attack = attack;
	}
}
