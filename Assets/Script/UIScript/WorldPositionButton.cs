using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldPositionButton : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private RectTransform rectTransform;
   
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(target!= null)
        {
            Vector3 Screenpoint = Camera.main.WorldToScreenPoint(target.position);
            rectTransform.position = Screenpoint;

            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(target.position);
            float distanceCenter = Vector2.Distance(viewportPoint, Vector2.one * 0.5f);
        }

    }
}
