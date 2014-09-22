using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopAppMart : MonoBehaviour
{
		//　appmartプラグイン
		public static AppMart_Android appmart_shop;

		//debugステータス
		public bool isDebug = true;

		//singleton
		private static ShopAppMart instance = null;

		//決済ID
		public string settlementId ;

		//初期化
		void Awake ()
		{
				if (instance == null) { 
						instance = this;
						DontDestroyOnLoad (transform);
						#if UNITY_ANDROID
												
						if (appmart_shop == null)
							appmart_shop = new AppMart_Android (gameObject.name, "RecievedResultAppMart",isDebug);
					
						#endif
				} 				
		}

		// アイテム設定
		public void SetListItem(List<string> listItem)
		{
			if (appmart_shop != null) 
				appmart_shop.SetListItem (listItem);
		}


		//クリック処理
		public void BuyItem (string item)
		{
				#if UNITY_ANDROID
				if (appmart_shop != null) {	
						Debug.Log ("Unity::AppMart =>>>> item = " + item);					
						appmart_shop.BuyItem (item);
				}
				#endif
		}


		// appmartよりのcallback
		public void RecievedResultAppMart (string item)
		{
				#if UNITY_ANDROID
				Debug.Log ("Unity::AppMart =>>>> item = " + item);	

				if (!item.Contains("Error") && !item.Contains("Resume")) 				
				{
					
					if(item.Contains("WaitForValidationPurchase")){

						//決済IDを保存
						settlementId = item.Split('=')[1] ;

						// TODO ユーザーにコンテンツ提供

						//決済確定
						appmart_shop.ConfirmSettlement();

					}else if (item.Contains("successPurchase")){
						//決済成功
						Debug.Log ("Unity::AppMart =>>>> buy app mart Ok " );
						DialogMSG.Inst().SetMSG("Purchase Ok:"+ settlementId )	;
						DialogMSG.Inst().Show();
					}
				}
				else
				{

					Debug.Log ("Unity::AppMart =>>>> buy appmart false :"+item );

						if(item.Contains("Not AppMart"))
						{
							
							//appmartがインストールされていません
							Debug.Log ("Unity::AppMart =>>>> Appmart not install " );
							DialogMSG.Inst().SetMSG("Appmart not install")	;
							DialogMSG.Inst().Show();

						}
						else{

							//その他のエラーが発生しました
							DialogMSG.Inst().SetMSG("buy appmart false :"+item )	;
							DialogMSG.Inst().Show();
						}
						
				}
				
				#endif
		}
}
