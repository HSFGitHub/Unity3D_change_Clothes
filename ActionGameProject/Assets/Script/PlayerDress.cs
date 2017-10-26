using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDress : MonoBehaviour {

	/// <summary>
	/// 头部
	/// </summary>
	public SkinnedMeshRenderer headRender;

	/// <summary>
	/// 手
	/// </summary>
	public SkinnedMeshRenderer handRender;

	/// <summary>
	/// 全身颜色
	/// </summary>
	public SkinnedMeshRenderer[] bodyArray;


	// Use this for initialization
	void Start () {
		InitDress();
	}
	
	void InitDress(){

		int headMeshIndex = PlayerPrefs.GetInt("HeadMeshIndex");
		int handIndex  = PlayerPrefs.GetInt("HandMeshIndex");
		int coloIndex = PlayerPrefs.GetInt("ColorIndex");

		headRender.sharedMesh = Menu_Contronller._instance.headMeshArray[headMeshIndex];

		handRender.sharedMesh = Menu_Contronller._instance.handMeshArray[handIndex];

		foreach (SkinnedMeshRenderer render in bodyArray)
		{
			render.material.color = Menu_Contronller._instance.colorArray[coloIndex];
		}
	}
}
