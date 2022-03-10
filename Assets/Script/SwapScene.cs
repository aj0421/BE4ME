using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    //public Button swap;
    //public List<GameObject> test;
    //private void Start()
    //{
    //    swap.onClick.AddListener(ButtonClicked);
    //}
    private void ButtonClicked()
    {
        Debug.Log("PRESSED");
       // SceneTransitionManager.Instance.GoToScene("MapScene", test);

    }

    public void Swap(int ID)
    {
        SceneManager.LoadScene(ID);
    }
}
