
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppMart_Android
{
	#if UNITY_ANDROID
	
	public  string APPMART_DEVELOPER_ID = "DEVELOPER-ID";
	public  string APPMART_LICENSE_KEY = "LICENSE_KEY";
	public  string APPMART_PUBLIC_KEY = "PUBLIC_KEY";
	public  string APPMART_APP_ID = "APP_ID";

		public  string objEvent = "shop";
		public  string handlerRecievedResultAppMart = "RecievedResultAppMart";

		public List<string> listItem = new List<string>();
	
		public AndroidJavaObject _appMart;
	
		public bool IsDebug = false;
	
		public AppMart_Android ()
		{
		if(IsDebug)
				Debug.Log ("unity  :Appmart Core init ");
				inst ();
		}
	
		public AppMart_Android (string ObjEvent, string HandlerEvent,bool isDebug)
		{
				objEvent = ObjEvent;
				handlerRecievedResultAppMart = HandlerEvent;
				IsDebug = isDebug;
				if(IsDebug)
					Debug.Log ("unity  :Appmart Core init ");
				inst ();
		}
	
		public void SetListItem(List<string> list)
		{
			listItem = list;
		}


		public bool IsCheckItem(string item)
		{
			return listItem.Contains(item);
		}

		
		public void BuyItem (string idItem)
		{

			#if UNITY_ANDROID
			if (_appMart == null) {
				if(IsDebug)
					Debug.Log ("unity : app mart null");
				inst ();
			}

			if(IsDebug)
				Debug.Log ("unity  :Appmart Click Item = " + idItem);

			try {
				_appMart.Call ("Click", new object[]{idItem});
			} catch {
			}
			#endif
		}
	
		public void ConfirmSettlement ()
		{
			
			#if UNITY_ANDROID
			if (_appMart == null) {
				if(IsDebug)
					Debug.Log ("unity : app mart null");
				inst ();
				
			}
			if(IsDebug)
				Debug.Log ("unity  :Appmart ConfirmSettlement");
			try {
				_appMart.Call ("confirmSettlement");
			} catch {
			}
			#endif
		}

	
		void inst ()
		{
			#if UNITY_ANDROID
			try {
				_appMart = new AndroidJavaObject ("jp.app_mart.plugin.PNUnityPlugin_AppMart", new object[]{objEvent,handlerRecievedResultAppMart,
				APPMART_DEVELOPER_ID,APPMART_LICENSE_KEY,APPMART_PUBLIC_KEY,APPMART_APP_ID,(IsDebug?1:0)});
			} catch(UnityException e) {
				Debug.Log ("unity  :Appmart EXP = " + e.Message);
			}
			#endif
		}


#endif
}


