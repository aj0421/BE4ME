using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    #region Variable
    #endregion

    #region Method
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    #endregion
}
