using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    #region Variables
    public GameObject[] characterArray;

    private GameObject quizPrefab;
    #endregion

    #region Method
    public void Start()
    {
        quizPrefab = FindMyGameObject("CanvasQuiz");
    }
    private GameObject FindMyGameObject(string name)
    {
        foreach (GameObject prefabToSpawn in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (prefabToSpawn.CompareTag(name))
            {
                return prefabToSpawn;
            }
        }
        return null;
    }

    public void ActivateQuiz()
    {
        quizPrefab.SetActive(true);
    }
    #endregion
}
