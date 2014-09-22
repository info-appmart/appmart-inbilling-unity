using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Main Script
public class AppMartBuyControl : MonoBehaviour {

	// アイテム名
	public List<string> listItem = new List<string>(){
		"my-item-1",
		"my-item-2"
	};

	// appmartプラグインに接続するShopAppMartオブジェクト
	public ShopAppMart shop;
	
	void Start () {
		if(shop == null)
			shop = (ShopAppMart)GetComponent<ShopAppMart>();
		shop.SetListItem(listItem);
	}

	void Update () {
	}

	// listItemを元に、ボタン作成
	// ボタンをクリックすると、BuyItemが呼び出される
	void OnGUI()
	{
		for(int i=0 ; i<listItem.Count ; i++)
		{
			if (GUI.Button(new Rect(10,20+i*70,120,50),listItem[i]))
			{
				Debug.Log("Clicked the button with text "+listItem[i]);
				if(shop != null)
					shop.BuyItem(listItem[i]);
			}
			
		}
	}
}