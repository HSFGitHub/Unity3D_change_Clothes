using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Contronller : MonoBehaviour
{

	public static Menu_Contronller _instance;
	public Color purple;

	//头部
	public SkinnedMeshRenderer headRenderer;
	//更换头部所存放的数组
	public Mesh[] headMeshArray;
	//当前播放的下标
	private int headMeshIndex = 0;


	//手部的相关换肤操作
	public SkinnedMeshRenderer handRenderer;
	public Mesh[] handMeshArray;
	private int handMeshIndex = 0;

	//改变全部颜色
	public SkinnedMeshRenderer[] allChangeColor;


	//存颜色
	[HideInInspector]
	public Color[] colorArray;

	private int colorIndex = -1;


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
		//初始化颜色数组
		colorArray = new Color[]{Color.blue,Color.cyan,Color.green,purple,Color.red};

		//不去销毁游戏物体时，对应的相关方法与变量都不会消失
		DontDestroyOnLoad(this.gameObject);
	}


	public void OnHeadMeshNext ()
	{
		headMeshIndex++;
		headMeshIndex %= headMeshArray.Length;
		headRenderer.sharedMesh = headMeshArray [headMeshIndex];

	}


	public void OnHandMeshNext ()
	{
		handMeshIndex++;
		handMeshIndex %= handMeshArray.Length;
		handRenderer.sharedMesh = handMeshArray [handMeshIndex];

	}

	public void OnChangeColorBlue ()
	{ colorIndex = 0 ;
		OnChangeColor (Color.blue);
	}

	public void OnChangeColorCyan ()
	{
		colorIndex = 1;
		OnChangeColor (Color.cyan);
	}

	public void OnChangeColorGreen ()
	{
		colorIndex = 2;
		OnChangeColor (Color.green);
	}

	public void OnChangeColorPurple ()
	{
		colorIndex = 3;
		OnChangeColor (purple);
	}

	public void OnChangeColorRed ()
	{
		colorIndex = 4;
		OnChangeColor (Color.red);
	}


	void OnChangeColor (Color color)
	{

		foreach (SkinnedMeshRenderer item in allChangeColor)
		{
			item.material.color = color;
		}
	}

	void Save(){
		PlayerPrefs.SetInt("HeadMeshIndex",headMeshIndex);
		PlayerPrefs.SetInt("HandMeshIndex",handMeshIndex);
		PlayerPrefs.SetInt("ColorIndex",colorIndex);
	}

	public void OnPlay ()
	{
		Save();
		//加载下一游戏场景
		Application.LoadLevel(1);
	}
}
