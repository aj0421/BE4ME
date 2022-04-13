using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotateCamera : MonoBehaviour
{
    #region variables
    public Camera camera;
    public float rotationSpeed = 0.1f;
    public float rotationDirection = -1;  //Negative direction

    private Touch first_touch = new Touch();
    private float rotationX = 0f;
    private float rotationY = 0f;
    private Vector3 originRotation;

    #endregion

    #region Methods

    void Start()
    {
        originRotation = camera.transform.localEulerAngles;
        rotationX = originRotation.x;
        rotationY = originRotation.y;
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
                //Calculate the position where the touch comes from depending on the touch-position on the screen.
                float deltaX = first_touch.position.x - touch.position.x;
                float deltaY = first_touch.position.y - touch.position.y;

                rotationX -= deltaY * Time.deltaTime * rotationSpeed * rotationDirection;
                rotationY += deltaX * Time.deltaTime * rotationSpeed * rotationDirection;

                rotationX = Mathf.Clamp(rotationX, 50f, 70f);  //THIS IS WERE WE CONTROL HOW MUCH THE USER CAN ROTATE THE CAMERA - TRY OUT DIFFERENT VALUES
               // rotationY = Mathf.Clamp(rotationY, 20f, -20f);
                camera.transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
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
