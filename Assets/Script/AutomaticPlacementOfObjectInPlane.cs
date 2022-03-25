using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class AutomaticPlacementOfObjectInPlane : MonoBehaviour
{
    private GameObject placedPrefab;

    private GameObject placedObject;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private ARPlaneManager ARPlaneManager;

    [SerializeField]
    private Button play;

    [SerializeField]
    private Button pause;

    [SerializeField]
    private Text instruction;

    private string storedValue;

    private int year;

    private GameObject[] characters;

    private void Awake()
    {
      
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARPlaneManager.planesChanged += PlaneChanged;
    }
  
    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && placedObject == null)
        {
            ARPlane arPlane = args.added[0];
            CheckCharacter(arPlane.transform.position);
          //  placedObject = Instantiate(placedPrefab, arPlane.transform.position, Quaternion.identity);
            play.gameObject.SetActive(true);
            pause.gameObject.SetActive(true);
            instruction.gameObject.SetActive(false);
        }
    }

    private void CheckCharacter(Vector3 position)
    {
        GameObject characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        characters = characterManager.gameObject.GetComponent<CharacterManager>().characterArray;
        storedValue = characterManager.gameObject.GetComponent<CharacterManager>().storedValue;
      
        foreach (var item in characters)
        {
            string yearFromCharacter = item.GetComponent<Character>().year;
            if (yearFromCharacter == storedValue)
            {
                placedPrefab = item;
                placedObject = Instantiate(placedPrefab, position, Quaternion.identity);
                Debug.Log("AutomaticPlacementOfObjectInPlane : CheckCharacter : spawning this " + placedObject.name + "and year " + yearFromCharacter);
            }
        }
    }
}
