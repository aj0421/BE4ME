using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Varibales
    public GameObject blackSquare;

    [HideInInspector]
    public Image squareImage;

    private float fadeAmount;

    #endregion

    #region Methods

    public void Start()
    {
        if(blackSquare != null)
        {
            squareImage = blackSquare.GetComponent<Image>();
            squareImage.color = new Color(1, 1, 1, 0);
        }
    }

    public IEnumerator FadeToBlack(bool fadeToBlack_ = true, float fadespeed_ = 0.5f)
    {
        Color fadeColor = squareImage.color;
        if (fadeToBlack_)
        {
            while (squareImage.color.a < 1)
            {
                fadeAmount = fadeColor.a + (fadespeed_ * Time.deltaTime);
                fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
                squareImage.color = fadeColor;
                yield return null;
            }
        }
        else
        {
            while (squareImage.color.a > 0)
            {
                fadeAmount = fadeColor.a - (fadespeed_ * Time.deltaTime);
                fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
                squareImage.color = fadeColor;
                yield return null;
            }
        }
    }

    #endregion
}
