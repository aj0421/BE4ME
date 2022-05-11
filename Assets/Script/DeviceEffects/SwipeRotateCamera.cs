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
    private Vector3 initialCameraPosition;
    public GameObject playerPosition;
    #endregion

    #region Methods

    void Start()
    {
        initialCameraPosition = camera.transform.position;
        coordinate = playerPosition.transform.position;
        camera.transform.LookAt(coordinate);
    }

    public void ResetCamera()
    {
        camera.transform.position = initialCameraPosition;
        camera.transform.LookAt(playerPosition.transform.position);
    }

    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)  //First touch we do on the screen
            {
                first_touch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)   //If we have moved fingers on the screen
            {
                camera.transform.RotateAround(playerPosition.transform.position, new Vector3(0, 1, 0), 10 * Time.deltaTime * rotationSpeed);

                camera.transform.LookAt(playerPosition.transform.position);
                if (!playerPosition.GetComponent<Renderer>().isVisible)
                {
                    camera.transform.LookAt(playerPosition.transform.position);
                }

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
