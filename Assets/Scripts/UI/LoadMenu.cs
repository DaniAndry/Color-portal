using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
[SerializeField] private InitializingSDK sdk;

    private void FixedUpdate()
    {
        sdk.SDKInitialized += Load;
    }
    private void Load()
    {
        SceneManager.LoadScene(1);
    }
}
