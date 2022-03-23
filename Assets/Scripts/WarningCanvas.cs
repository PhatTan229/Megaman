using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WarningCanvas : MonoBehaviour
{
    public AudioSource warningSoundController;
    public TMP_Text warningText;
    public float colorChangingDelay;
    private Color[] colorArray = { Color.red, Color.black };
    private int currentColor;
    private void Awake()
    {
        currentColor = 0;
        ChangeTextColor();
    }
    private void ChangeTextColor()
    {
        warningText.color = colorArray[currentColor % 2];
        currentColor = currentColor + 1;

        if (currentColor < 9) Invoke(nameof(ChangeTextColor), colorChangingDelay);



    }


}
