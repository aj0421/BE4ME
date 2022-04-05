using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private AbstractMap map;

    public Vector2d position;

    public GameObject prefab;

    #region Singelton
    public static DataHandler Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //position = new Vector3(0, 0, 0).GetGeoPosition(map.CenterMercator, map.WorldRelativeScale);
    }
    #endregion

    #endregion

    #region Method
    private void LateUpdate()
    {
        position = new Vector3(0, 0, 0).GetGeoPosition(map.CenterMercator, map.WorldRelativeScale);
    }
    //var lat = prefab.transform.GetGeoPosition(new Vector2d(0, 0), 1);
 
   

    #endregion

}
