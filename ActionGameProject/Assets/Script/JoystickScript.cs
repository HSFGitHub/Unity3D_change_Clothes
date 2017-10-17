using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickScript : MonoBehaviour {

	private bool isPress = false;
	private Transform buttonTransform;

    public static float h = 0;
	public static float v = 0;

	//当在屏幕上点击时，会发出按下的通知，OnPress是通知的方法,捕获当前按下的操作。
	void OnPress(bool isPress){
        this.isPress = isPress;
		if (isPress == false)
		{
			buttonTransform.localPosition = Vector3.zero;
			h = 0;
			v = 0;
		}
	}


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		buttonTransform = transform.Find("JoystickBotton");	
	}
    /// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(isPress){
			Vector2 touchPos = UICamera.lastTouchPosition;
			touchPos -= new Vector2(91f,91f);

			float distance = Vector2.Distance(Vector2.zero,touchPos);
			if (distance > 73)
			{
				buttonTransform.localPosition = touchPos.normalized * 73;
			}else{
				buttonTransform.localPosition = touchPos;
			}

			//处理控制器位置
			h = touchPos.x / 73;
			v = touchPos.y / 73;
		}
	}
   
}
