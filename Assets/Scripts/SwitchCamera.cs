using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject targetCamera;
    public GameObject[] otherCameras;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player")) return;
        Debug.Log("Swith Camera");
        targetCamera.SetActive(true);
        for (int i = 0; i < otherCameras.Length; i++)
        {
            otherCameras[i].SetActive(false);
        }
    }
}
