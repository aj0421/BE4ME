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
    private GameObject characterParent;

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

    private List<GameObject> characters;

    public Transform target;
    public void Awake()
    {
        //For debug purpose
      // CheckCharacter(new Vector3(0, 0, 0));
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARPlaneManager.planesChanged += PlaneChanged;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && placedObject == null)
        {
            ARPlane arPlane = args.added[0];
            CheckCharacter(arPlane.transform.position);
            play.gameObject.SetActive(true);
            pause.gameObject.SetActive(true);
            instruction.gameObject.SetActive(false);
        }
    }

    private void CheckCharacter(Vector3 position)
    {
        GameObject characterManager = GameObject.FindGameObjectWithTag("CharacterManager");
        characters = FindList("Character");
        storedValue = characterManager.gameObject.GetComponent<CharacterManager>().storedValue;

        foreach (GameObject item in characters)
        {
            string yearFromCharacter = item.GetComponent<Character>().year;
            if (yearFromCharacter == storedValue)
            {
                placedPrefab = item;
                placedObject = Instantiate(placedPrefab, position, Quaternion.identity);
                placedObject.transform.SetParent(characterParent.transform, false);
                placedObject.transform.position += new Vector3(0, -2, 0);
                placedObject.transform.LookAt(target);
            }
        }
    }

    private List<GameObject> FindList(string name)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (GameObject prefabToSpawn in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (prefabToSpawn.CompareTag(name))
            {
                temp.Add(prefabToSpawn);
            }
        }
        return temp;
    }
}
