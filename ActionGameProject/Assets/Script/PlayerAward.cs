using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAward : MonoBehaviour {

	/// <summary>
	/// 单韧剑
	/// </summary>
	public GameObject singleSwordGo;

	/// <summary>
	/// 双韧剑
	/// </summary>
	public GameObject dualSwordGo;

	/// <summary>
	/// 枪
	/// </summary>
	public GameObject gunSwordGo;


	/// <summary>
	/// 奖励武器存在的时间
	/// </summary>
	public float exitTime = 10;

	/// <summary>
	/// 双韧剑存在时间
	/// </summary>
	public float dualSwordTimer = 0;

	/// <summary>
	/// 枪存在的时间
	/// </summary>
	public float gunTimer = 0;


	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		//对双韧剑计时
		 if (dualSwordTimer > 0)
		 {
			 dualSwordTimer -= Time.deltaTime;
			 if (dualSwordTimer < 0)
			 {
				 TurnToSingalSword();
			 }
			 
		 }

		 if (gunTimer > 0)
		 {
			 gunTimer -= Time.deltaTime;
			 if (gunTimer < 0)
			 {
				  TurnToSingalSword();
			 }
			 
		 }
	}

/***********************自定义方法**************************/
	public void GetAward(AwardType type){

		if (type == AwardType.DualSword)
		{
			TurnToDualSword();
		}else if (type == AwardType.Gun)
		{
			TurnToGunSword();
		}

	}

	void TurnToDualSword(){
		dualSwordGo.SetActive(true);
		singleSwordGo.SetActive(false);
		gunSwordGo.SetActive(false);
		dualSwordTimer = exitTime;
		gunTimer = 0;
	}

	void TurnToGunSword(){
		dualSwordGo.SetActive(false);
		singleSwordGo.SetActive(false);
		gunSwordGo.SetActive(true);
		gunTimer = exitTime;
		dualSwordTimer = 0;
	}

	void TurnToSingalSword(){
		dualSwordGo.SetActive(false);
		singleSwordGo.SetActive(true );
		gunSwordGo.SetActive(false);
		dualSwordTimer = 0;
		gunTimer = 0;
	}
}
