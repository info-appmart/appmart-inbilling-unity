using UnityEngine;
using System.Collections;

public class DialogMSG : MonoBehaviour {

	private static DialogMSG _Inst;
	private string _title="Information",_msg="";
	private bool isShow =  false;
	
	void Start () {
		_Inst =  this;		
	}

	void Update () {
	}

	//　Boxを生成
	void OnGUI()
	{
		if(isShow)
		{
			GUI.Box(new Rect(Screen.width/2-100,Screen.height/2-75,200,150),_title);
			GUI.Label(new Rect(Screen.width/2 - 90,Screen.height/2-15,180,100),_msg);
			if(GUI.Button(new Rect(Screen.width/2-30,Screen.height/2 +20,60,30),"OK"))
			{
				Hide();
			}
		}
	}
	public void SetTitle(string title)
	{
		_title = title;
	}
	public void SetMSG(string msg)
	{
		_msg = msg;
	}
	public void Show()
	{
		isShow = true;
	}
	public void Hide()
	{
		isShow = false;
	}
	public void DestroyDiglog()
	{
		Destroy(gameObject);
		_Inst = null;
	}
	public static DialogMSG Inst()
	{
		if(_Inst == null)
		{
			GameObject go = new GameObject();
			_Inst = go.AddComponent<DialogMSG>();
		}
		return _Inst;
	}
}
