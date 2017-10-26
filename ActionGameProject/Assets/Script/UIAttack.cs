using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttack : MonoBehaviour {

	//静态方法
	public static UIAttack _instance;

	//普通攻击按钮
	public GameObject normalAttack;

	//范围攻击按钮
	public GameObject rangeAttack;

	//红色按钮
	public GameObject redAttack;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_instance = this;
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		normalAttack = transform.Find("NormalAttack").gameObject;
		rangeAttack  = transform.Find("RangeAttack").gameObject;
		redAttack  = transform.Find("RedAttack").gameObject;
	}


	/// <summary>
	/// 红色按钮，隐藏其他按钮
	/// </summary>
	public void TurnToOneAttack(){
		normalAttack.SetActive(false);
		rangeAttack.SetActive(false);
		redAttack.SetActive(true);
	}

	/// <summary>
	/// 普通攻击面板
	/// </summary>
	public void TurnToTwoAttack(){
		normalAttack.SetActive(true);
		rangeAttack.SetActive(true);
		redAttack.SetActive(false);
	}


}
