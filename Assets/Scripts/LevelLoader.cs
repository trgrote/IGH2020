using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject _galaxyRootObject;
    [SerializeField, rho.Scene] string _worldSceneName;

    [SerializeField] so_events.Event _onUnloadCompleteEvent;

    LoadSceneParameters _loadParams = new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.None);

    Scene _worldScene;
    bool _worldSceneLoaded = false;
    bool _processing = false;

    public void LoadWorldScene()
    {
        if (!_processing && !_worldSceneLoaded)
        {
            StartCoroutine(LoadWorldSceneCoroutine());
        }
    }

    public void UnloadWorldScene()
    {
        if (!_processing && _worldSceneLoaded)
        {
            StartCoroutine(UnloadWorldSceneCoroutine());
        }
    }

    IEnumerator LoadWorldSceneCoroutine()
    {
        _processing = true;
        _galaxyRootObject.SetActive(false);
        _worldScene = SceneManager.LoadScene(_worldSceneName, _loadParams);
        yield return null;    // wait a frame before settint active scene
        SceneManager.SetActiveScene(_worldScene);
        _worldSceneLoaded = true;
        _processing = false;
    }

    IEnumerator UnloadWorldSceneCoroutine()
    {
        _processing = true;
        var unloadProc = SceneManager.UnloadSceneAsync(_worldScene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        while (!unloadProc.isDone)
        {
            yield return null;
        }
        _galaxyRootObject.SetActive(true);
        _worldSceneLoaded = false;
        _onUnloadCompleteEvent.Raise();
        _processing = false;
    }
}
