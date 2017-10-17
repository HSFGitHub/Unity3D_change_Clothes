using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private CharacterController cc;

	private Animator playerAnimator;

	//开发一个速度变量
	public float speed = 4;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		cc = this.GetComponent<CharacterController> ();
		playerAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    float h = Input.GetAxis("Horizontal");
		float v  = Input.GetAxis("Vertical");

		if (JoystickScript.h != 0 || JoystickScript.v != 0)
		{
			h = JoystickScript.h;
			v = JoystickScript.v;
		}

		if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
		{
			//人物状态改为跑状态
			playerAnimator.SetBool("Walk",true);


			//防止，行走的同时出现攻击状态
			if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
			{
				Vector3 targetDir =  new Vector3(h,0,v);
			
				//查看的位置
				transform.LookAt(targetDir + transform.position);
				//移动
				cc.SimpleMove(transform.forward * speed);	
			}
			
		}else{
			//人物状态改为停止状态
			playerAnimator.SetBool("Walk",false);
		}

		
	}
}
