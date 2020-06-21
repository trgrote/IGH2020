using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject _galaxyRootObject;
    [SerializeField, rho.Scene] string _worldSceneName;

    LoadSceneParameters _loadParams = new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.Physics3D);

    Scene _worldScene;
    bool _worldSceneLoaded = false;

    public void LoadWorldScene()
    {
        if (!_worldSceneLoaded)
        {
            StartCoroutine(LoadWorldSceneCoroutine());
        }
    }

    public void UnloadWorldScene()
    {
        if (_worldSceneLoaded)
        {
            StartCoroutine(UnloadWorldSceneCoroutine());
        }
    }

    IEnumerator LoadWorldSceneCoroutine()
    {
        _galaxyRootObject.SetActive(false);
        _worldScene = SceneManager.LoadScene(_worldSceneName, _loadParams);
        yield return null;    // wait a frame before settint active scene
        SceneManager.SetActiveScene(_worldScene);
        _worldSceneLoaded = true;
    }

    IEnumerator UnloadWorldSceneCoroutine()
    {
        var unloadProc = SceneManager.UnloadSceneAsync(_worldScene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

        while (!unloadProc.isDone)
        {
            yield return null;
        }
        _galaxyRootObject.SetActive(true);
        _worldSceneLoaded = false;
    }
}
