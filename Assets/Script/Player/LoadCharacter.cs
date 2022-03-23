using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawnLocation;
    public Transform parent;
    public Text savedPlaterText;

    private Animator playerAnimator;
    private Vector3 scaleChange;
    private Vector3 positionChange;
    private GameObject characterPrefab;
    private GameObject prefabClone;
    private int currentCharacter;
    private string playerName;
        private Image playerIcon;

    private void Start()
    {
        currentCharacter = PlayerPrefs.GetInt("selectedCharacter");
        playerName = PlayerPrefs.GetString("name");
        savedPlaterText.text = playerName;

        characterPrefab = characters[currentCharacter];
        prefabClone = Instantiate(characterPrefab, parent.position, parent.rotation);
        scaleChange = new Vector3(20, 20, 20);
        positionChange = new Vector3(0, 20, 0);
        prefabClone.transform.localScale += scaleChange;
        prefabClone.transform.position += positionChange;
        prefabClone.transform.SetParent(parent);

        //Animation
        playerAnimator = prefabClone.GetComponent<Animator>();
        IsWalking();
    }

    private bool IsWalking()
    {
        //TODO: Check if player is moving then return true else return false

        Debug.Log("LOAD CHARACTER IsWalking: Player " + prefabClone.name + ", player animator: " + playerAnimator);

        if(playerAnimator != null)
        {
            playerAnimator.Play("WalkForward");
            Debug.Log("Playing WalkForward");
        }

        return true;
    }
}
