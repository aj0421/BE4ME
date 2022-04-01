using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    #region Variables
    public GameObject[] characterArray;

    public string storedValue;
    private static CharacterManager instance;

    public bool isCompleted;
    #endregion

    #region Method
    private void Awake()
    {
        foreach (var item in characterArray)
        {
            isCompleted = item.GetComponent<Character>().isCompleted;
        }
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
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
    #endregion
}
