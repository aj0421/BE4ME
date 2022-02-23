using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class AutomaticPlacementOfObjectInPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    private GameObject placedObject;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private ARPlaneManager ARPlaneManager;

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
            placedObject = Instantiate(placedPrefab, arPlane.transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        
    }
}
