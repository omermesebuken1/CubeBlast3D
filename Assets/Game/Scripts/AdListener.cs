using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;

public class AdListener : IRewardedVideoAdListener
{

    private void Awake()
    {
        Appodeal.SetRewardedVideoCallbacks(this);
    }

    #region Rewarded Video callback handlers

    //Called when rewarded video was loaded (precache flag shows if the loaded ad is precache).
    public void OnRewardedVideoLoaded(bool isPrecache)
    {
        Debug.Log("Video loaded");
    }

    // Called when rewarded video failed to load
    public void OnRewardedVideoFailedToLoad()
    {
        Debug.Log("Video failed");
    }

    // Called when rewarded video was loaded, but cannot be shown (internal network errors, placement settings, or incorrect creative)
    public void OnRewardedVideoShowFailed()
    {
        Debug.Log("Video show failed");
    }

    // Called when rewarded video is shown
    public void OnRewardedVideoShown()
    {
        Debug.Log("Video shown");
    }

    // Called when reward video is clicked
    public void OnRewardedVideoClicked()
    {
        Debug.Log("Video clicked");
    }

    // Called when rewarded video is closed
    public void OnRewardedVideoClosed(bool finished)
    {
        Debug.Log("Video closed");
    }

    // Called when rewarded video is viewed until the end
    public void OnRewardedVideoFinished(double amount, string name)
    {
        Debug.Log("Reward: " + amount + " " + name);
    }

    //Called when rewarded video is expired and can not be shown
    public void OnRewardedVideoExpired()
    {
        Debug.Log("Video expired");
    }

    #endregion



}
