using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawnLocation;

    private void Start()
    {
        int currentCharacter = PlayerPrefs.GetInt("selectedCharacter");
        string name = PlayerPrefs.GetString("name");
        GameObject characterPrefab = characters[currentCharacter];
        GameObject prefabClone = Instantiate(characterPrefab, spawnLocation.position, Quaternion.identity);
    }
}
