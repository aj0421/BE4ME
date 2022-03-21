using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class AutomaticPlacementOfObjectInPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    //[SerializeField]
    //private GameObject quizPrefab;

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
    private Button repeat;

    [SerializeField]
    private Text instruction;

    private void Awake()
    {
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARPlaneManager.planesChanged += PlaneChanged;
        placedObject = Instantiate(placedPrefab, transform.position, Quaternion.identity);
    }
  
    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && placedObject == null)
        {
            ARPlane arPlane = args.added[0];
            placedObject = Instantiate(placedPrefab, arPlane.transform.position, Quaternion.identity);
            play.gameObject.SetActive(true);
            pause.gameObject.SetActive(true);
            repeat.gameObject.SetActive(true);
           // quizPrefab.gameObject.SetActive(true);
            instruction.gameObject.SetActive(false);
        }
    }
}
