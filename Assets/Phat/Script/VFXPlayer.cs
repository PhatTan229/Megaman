using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject PlayAnimation(GameObject vfxClip, Vector3 position, Quaternion rotation)
    {
        var g = Instantiate(vfxClip, position, rotation);
        return g;
    }
}
