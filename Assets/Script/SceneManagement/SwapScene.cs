using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    public void Swap(int ID)
    {
        SceneManager.LoadScene(ID);
    }
}
