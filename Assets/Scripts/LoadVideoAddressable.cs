using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadVideoAddressable : MonoBehaviour {

    [SerializeField]
    private AssetReference asset;
    [SerializeField]
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start() {

        videoPlayer.errorReceived += (source, message) =>
        {
            Debug.LogError($"{source.clip.name} load failed. Path: {source.clip.originalPath}");
            Debug.LogError(message);
        };
        Addressables.LoadAssetAsync<VideoClip>(asset).Completed += handle =>
        {
            videoPlayer.clip = handle.Result;
            videoPlayer.Play();
        };
        
    }

}
