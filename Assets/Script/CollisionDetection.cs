using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    #region Variable
    [SerializeField]
    private Button button;

    [SerializeField]
    private Button timeMachineButton;
    
    [SerializeField]
    private Dropdown dropDown;
    #endregion

    #region Method
    private void Start()
    {
        if(button == null && timeMachineButton == null)
        {
            button = GameObject.Find("ButtonHandler").GetComponentInChildren<Button>();
            timeMachineButton = GameObject.Find("ButtonHandler").GetComponentInChildren<Button>();
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Marker"))
        {
            Vibration.Vibrate(1000);
            other.GetComponent<MeshRenderer>().material.color = Color.yellow;
            button.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("TimeMachine"))
        {
            timeMachineButton.gameObject.SetActive(true);
            dropDown.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Marker"))
        {
            other.GetComponent<MeshRenderer>().material.color = Color.gray;
            button.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("TimeMachine"))
        {
            timeMachineButton.gameObject.SetActive(false);
            dropDown.gameObject.SetActive(false);
        }
    }
    #endregion
}
