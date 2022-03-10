using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private Button button;
    #endregion

    #region Method
    private void Start()
    {
        if(button == null)
        {
            button = GameObject.Find("ButtonHandler").GetComponentInChildren<Button>();
        }
        else
        {
            Debug.Log("Button not found");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.red;
            button.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.blue;
            button.gameObject.SetActive(false);
        }
    }
    #endregion
}
