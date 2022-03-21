using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Variables

    private Vector3 originalPosition;
    private float elapsed;

    #endregion

    #region Methods

    //!-----INSTRUCTIONS FOR USING CAMERA SHAKE-----!  THIS IS NOT HOOKED UP YET
    //Add Main Camera as a child to an empty gameobject called Camera Holder and reset pos/tran on that object.
    //Add this script as a component to the Main Camera.
    //When calling this method anywhere: Access the script trhough public CameraShake and drag n drop it in the editor.
    //Then call it by: StartCoroutine(cameraShake.Shake(0.3f, 0.5f)); (Edit values to preference)
    public IEnumerator Shake(float duration, float magnitude)
    {
        originalPosition = transform.localPosition;
        elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    #endregion
}
