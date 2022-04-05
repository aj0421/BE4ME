using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    private GameObject audioHandler;
    public void Awake()
    {
        audioHandler = GameObject.Find("AudioHandler");
    }
    public void Swap(int ID)
    {
        audioHandler.GetComponent<AudioHandler>().AddSoundEffects(this.gameObject, "button_tap");
        SceneManager.LoadScene(ID);
      
    }
}
