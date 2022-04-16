namespace Mapbox.Examples
{
    using UnityEngine;
    using Mapbox.Utils;
    using Mapbox.Unity.Map;
    using Mapbox.Unity.MeshGeneration.Factories;
    using Mapbox.Unity.Utilities;
    using System.Collections.Generic;
    using UnityEngine.UI;
    using System.Collections;

    public class SpawnOnMap : MonoBehaviour
    {
        [SerializeField]
        AbstractMap _map;

        [SerializeField]
        [Geocode]
        string[] _locationStrings;

        [SerializeField]
        [Geocode]
        string _locationTimeMachine;

        Vector2d[] _locations;

        Vector2d[] _timeMachinelocations;

        [SerializeField]
        float _spawnScale = 100f;

        [SerializeField]
        GameObject[] _markerPrefab;

        [SerializeField]
        GameObject _timeMachinePrefab;

        List<GameObject> _spawnedObjects;

        bool hasSpawned;

        void Start()
        {
            _locations = new Vector2d[_locationStrings.Length];
            _timeMachinelocations = new Vector2d[_locationTimeMachine.Length];
            _spawnedObjects = new List<GameObject>();
           
            for (int i = 0; i < _locationStrings.Length; i++)
            {
                string locationString = _locationStrings[i];
                _locations[i] = Conversions.StringToLatLon(locationString);
            }
            StartCoroutine(LateStart(1f));
            CheckYear();
        }
        IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            Initialize();
        }
        private void Initialize()
        {
            _timeMachinelocations[0] = Conversions.StringToLatLon(_locationTimeMachine);
            GameObject timeMachine = Instantiate(_timeMachinePrefab);
            timeMachine.transform.position = _map.GeoToWorldPosition(_timeMachinelocations[0], true);
            timeMachine.transform.position += new Vector3(0, 55, 0);  //NEW
        }

        private void CheckYear()
        {
            GameObject characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
            string storedValue = characterManager.GetComponent<CharacterManager>().storedValue;
            GameObject instance;
            if (storedValue == null)
            {
                return;
            }

            if (!hasSpawned)
            {
                switch (storedValue)
                {
                    case "1880":
                      
                        instance = Instantiate(_markerPrefab[0]);
                        instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                        instance.transform.localPosition = _map.GeoToWorldPosition(_locations[0], true);
                        _spawnedObjects.Add(instance);
                        hasSpawned = true;
                        characterManager.GetComponent<CharacterManager>().ChangeYearUI();
                        break;
                    case "1996":
                        instance = Instantiate(_markerPrefab[0]);
                        instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                        instance.transform.localPosition = _map.GeoToWorldPosition(_locations[1], true);
                        _spawnedObjects.Add(instance);
                        hasSpawned = true;
                        characterManager.GetComponent<CharacterManager>().ChangeYearUI();
                        break;
                    case "1969":
                        instance = Instantiate(_markerPrefab[0]);
                        instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                        instance.transform.localPosition = _map.GeoToWorldPosition(_locations[2], true);
                        _spawnedObjects.Add(instance);
                        hasSpawned = true;
                        characterManager.GetComponent<CharacterManager>().ChangeYearUI();
                        break;
                }
            }
        }

        private void Update()
        {
            int count = _spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                GameObject spawnedObject = _spawnedObjects[i];
                Vector2d location = _locations[i];
                spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            }
        }
    }
}