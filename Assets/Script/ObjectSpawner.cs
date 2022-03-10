using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private GameObject[] gameObjects;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private int startingCount = 1;

    private float minRange = 5.0f;
    private float maxRange = 10.0f;
    #endregion


    #region Method

    private void Start()
    {
        Spawn();
    }


    private void Spawn()
    {
        int index = Random.Range(0, gameObjects.Length);

        float x = player.position.x + 5f;
        float z = player.position.z;
        float y = player.position.y;
        Instantiate(gameObjects[index], new Vector3(x, y, z), Quaternion.identity);
    }


    #endregion

}
