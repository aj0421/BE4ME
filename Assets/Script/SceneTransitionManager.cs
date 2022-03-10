using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class SceneTransitionManager : MonoBehaviour
{
    static SceneTransitionManager mInstance;

    public static SceneTransitionManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject go = new GameObject();
                mInstance = go.AddComponent<SceneTransitionManager>();
            }
            return mInstance;
        }
    }
    #region Variables
    private AsyncOperation sceneAsync;

    public SceneTransitionManager(AsyncOperation sceneAsync)
    {
        this.sceneAsync = sceneAsync;
    }
    #endregion

    #region Methods


    public void GoToScene(string sceneName, List<GameObject> objectsToMove)
    {
        StartCoroutine(LoadScene(sceneName, objectsToMove));
    }

    private IEnumerator LoadScene(string sceneName, List<GameObject> objectsToMove)
    {
        SceneManager.LoadSceneAsync(sceneName);

        SceneManager.sceneLoaded += (newScene, mode) =>
        {
            SceneManager.SetActiveScene(newScene);
        };

        Scene sceneToLoad = SceneManager.GetSceneByName(sceneName);
        foreach (GameObject obj in objectsToMove) 
        {
            SceneManager.MoveGameObjectToScene(obj, sceneToLoad);
        }
        yield return null;
    }

    #endregion
}
