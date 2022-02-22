using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    #region Variable

    #endregion

    #region Method
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        CheckCollision(transform.GetComponent<SphereCollider>().center, transform.GetComponent<SphereCollider>().radius);
        //if (gameObject.CompareTag("Character"))
        //{
        //    Debug.Log("AAJ");

        //}
    }

    private void CheckCollision(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider hit in hitColliders)
        {
          
            if (hit.gameObject.CompareTag("Character"))
            {
                hit.gameObject.SetActive(false);
                Debug.Log("AJ");
            }
           
        }


    }


    #endregion
}
