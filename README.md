# Appmart　アプリ内課金 : Unity plugin

![last-version](http://img.shields.io/badge/last--version-1-green.svg "last version:1.1") 

![license apache 2.0](http://img.shields.io/badge/license-apache%202.0-brightgreen.svg "licence apache 2.0")

Appmartアプリ内課金システムのUnity pluginです。このサンプルをfork・cloneしていただき、自由にご利用ください。 

このサンプルの対象サービスは:

+ アプリ内課金：都度決済 



## Ready-to-useサンプル

##### 本リポジトリをcloneしてください

```shell
cd /home/user/mydirectory
git clone https://github.com/info-appmart/appmart-inbilling-unity.git
```

##### プロジェクトのパラメータを修正

> Plugins/Android/AppMart_Android.cs

```
public  string APPMART_DEVELOPER_ID = "YOUR_DEVELOPER_ID";
public  string APPMART_LICENSE_KEY = "YOUR_LICENSE_KEY";
public  string APPMART_PUBLIC_KEY = "YOUR_PUBLIC_KEY";
public  string APPMART_APP_ID = "YOUR_APPLICATION_ID";
```

> Scripts/AppMartBuyControl.cs

```
	public List<string> listItem = new List<string>(){
		"YOUR_ITEM-1",
		"YOUR_ITEM-2"
	};
```



## PluginのMethods

#### BuyItem (string itemId)

決済を行う処理です。決済が実行された後にUnityアプリに遷移されますがまだ確定されておりません。


#### ConfirmSettlement()

ユーザーにコンテンツを提供した後にConfirmSettlementで決済を確定させます。


## RecievedResultAppMartのitem値

 
| itemの値            | 備考                              |
| ---------------------- |------------------------------- |
|　WaitForValidationPurchase: transactionId= 【決済ID】| 決済成功（未確定）|
| successPurchase   |　決済成功（確定済み） |
|　Error: 【エラー内容】|渡されたパラメータが誤っている|

