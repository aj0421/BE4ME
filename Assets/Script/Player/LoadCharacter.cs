using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawnLocation;
    public Transform parent;

    private Vector3 scaleChange;
    private Vector3 positionChange;

    private void Start()
    {
        int currentCharacter = PlayerPrefs.GetInt("selectedCharacter");
        string name = PlayerPrefs.GetString("name");
        GameObject characterPrefab = characters[currentCharacter];
        GameObject prefabClone = Instantiate(characterPrefab, parent.position, parent.rotation);
        scaleChange = new Vector3(10, 30, 10);
        positionChange = new Vector3(0, 20, 0);
        prefabClone.transform.localScale += scaleChange;
        prefabClone.transform.position += positionChange;
        prefabClone.transform.SetParent(parent);
    }
}
