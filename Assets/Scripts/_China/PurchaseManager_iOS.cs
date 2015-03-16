using UnityEngine;
using System.Collections;
using Prime31;

public class PurchaseManager_iOS : MonoBehaviour {


	public GameObject loadingWindow;
	// Use this for initialization
	
#if UNITY_IPHONE
	void Start () 
	{
		bool canMakePayments = StoreKitBinding.canMakePayments ();
		Debug.Log ("StoreKit canMakePayments: " + canMakePayments);
		if (canMakePayments) 
		{
				StartCoroutine (RequestProductData ());

		}
	}

	IEnumerator RequestProductData()
	{
		yield return null;

		var productIdentifiers = new string[] { "com.joywinggames.MayDay.IosMedal011", "com.joywinggames.MayDay.IosMedal012", "com.joywinggames.MayDay.IosMedal013", "com.joywinggames.MayDay.IosMedal014", "com.joywinggames.MayDay.IosMedal015" };
		StoreKitBinding.requestProductData( productIdentifiers );

	}

	public IEnumerator Purchase20()
	{
		yield return null;
		loadingWindow.SetActive(true);
		gameObject.GetComponent<StoreKitEventListener> ().productNumber = 1;
		StoreKitBinding.purchaseProduct( "com.joywinggames.MayDay.IosMedal011", 1 );
		Debug.Log( "preparing to purchase product: " + "com.joywinggames.MayDay.IosMedal011" );

	}

	public IEnumerator Purchase50()
	{
		yield return null;
		loadingWindow.SetActive(true);
		gameObject.GetComponent<StoreKitEventListener> ().productNumber = 2;
		StoreKitBinding.purchaseProduct( "com.joywinggames.MayDay.IosMedal012", 1 );
		Debug.Log( "preparing to purchase product: " + "com.joywinggames.MayDay.IosMedal012" );
	}

	public IEnumerator Purchase100()
	{
		yield return null;
		loadingWindow.SetActive(true);
		gameObject.GetComponent<StoreKitEventListener> ().productNumber = 3;
		StoreKitBinding.purchaseProduct( "com.joywinggames.MayDay.IosMedal013", 1 );
		Debug.Log( "preparing to purchase product: " + "com.joywinggames.MayDay.IosMedal013" );
	}

	public IEnumerator Purchase300()
	{
		yield return null;
		loadingWindow.SetActive(true);
		gameObject.GetComponent<StoreKitEventListener> ().productNumber = 4;
		StoreKitBinding.purchaseProduct( "com.joywinggames.MayDay.IosMedal014", 1 );
		Debug.Log( "preparing to purchase product: " + "com.joywinggames.MayDay.IosMedal014" );
	}

	public IEnumerator Purchase1000()
	{
		yield return null;
		loadingWindow.SetActive(true);
		gameObject.GetComponent<StoreKitEventListener> ().productNumber = 5;
		StoreKitBinding.purchaseProduct( "com.joywinggames.MayDay.IosMedal015", 1 );
		Debug.Log( "preparing to purchase product: " + "com.joywinggames.MayDay.IosMedal015" );
	}

#endif
}
