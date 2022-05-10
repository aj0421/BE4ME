using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotateCamera : MonoBehaviour
{
    #region variables
    public Camera camera;
    public float rotationSpeed = 10f;

    private Touch first_touch = new Touch();
    private Vector3 coordinate;
    public GameObject playerPosition;
    #endregion

    #region Methods

    void Start()
    {
        coordinate = playerPosition.transform.position;
        camera.transform.LookAt(coordinate);
    }

    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)        //First touch we do on the screen
            {
                first_touch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)   //If we have moved fingers on the screen
            {
                camera.transform.RotateAround(coordinate, new Vector3(0, 1, 0), 10 * Time.deltaTime * rotationSpeed);

                camera.transform.LookAt(coordinate);

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                first_touch = new Touch();
            }
            else
            {
                Debug.Log("No Touch");
            }
        }
    }

    #endregion
}
