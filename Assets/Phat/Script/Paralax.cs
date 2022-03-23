using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float length, startPos;
    public float paralaxVFX;
    public Camera cam;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        cam = Camera.main;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float tmp = (cam.transform.position.x * (1 - paralaxVFX));
        float dis = (cam.transform.position.x * paralaxVFX);
        transform.position = new Vector3(startPos + dis,cam.transform.position.y , transform.position.z);

        if(tmp > startPos + length)
        {
            startPos += length;
        }
        else if( tmp < startPos - length)
        {
            startPos -= length;
        }
    }
}
