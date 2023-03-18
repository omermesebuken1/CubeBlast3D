// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using AppodealStack.Monetization.Api;
// using AppodealStack.Monetization.Common;
// using TMPro;


// public class AppodealAdBoi : MonoBehaviour
// {

//     [SerializeField] private GameObject adCanvas;
//     [SerializeField] private GameObject showAdButton;
//     [SerializeField] private TextMeshProUGUI adtext;

//     #region Initialization Callback
//     public void OnInitializationFinished(object sender, SdkInitializedEventArgs e)
//     {
//         Debug.Log("Initialization Finished");
//         adtext.text = "Initialization Finished";
//     }
//     #endregion

    

    

//     private void Start()
//     {
//         int adTypes = AppodealAdType.Interstitial | AppodealAdType.Banner | AppodealAdType.RewardedVideo | AppodealAdType.Mrec;
//         string appKey = "f9415c6631c19d2ebe4027873222eaed99c99a5eb854abce";
//         AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
//         Appodeal.Initialize(appKey, adTypes);
//         Appodeal.SetAutoCache(AppodealAdType.RewardedVideo, false);
//         showAdButton.SetActive(false);
//         adCanvas.SetActive(true);
//     }

//     private void Update()
//     {
//         if (Appodeal.IsLoaded(AppodealAdType.RewardedVideo))
//         {
//             showAdButton.SetActive(true);
//             adtext.text = "ad loaded";
//         }
//     }

//     public void LoadAd()
//     {
//         Appodeal.Cache(AppodealAdType.RewardedVideo);
//         adtext.text = "ad loading...";

//     }

//     public void ShowAd()
//     {
//         Appodeal.Show(AppodealShowStyle.RewardedVideo);
//         adtext.text = "showing ad";

//     }

//     public void closeAll()
//     {
//         adCanvas.SetActive(false);
//     }



// }
