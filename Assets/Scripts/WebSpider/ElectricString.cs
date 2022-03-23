using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricString : MonoBehaviour
{
    public LineRenderer render;
    public WebSpider spider;
    public Texture[] textures;
    public int fps;

    private Transform stringPoint;
    private float yTree;

    private float updatingInterval;
    private float nextUpdatingTime;
    private int animationStep;
    private int animationNumber;
    private void OnValidate()
    {
        render = GetComponent<LineRenderer>();
        spider = GetComponent<WebSpider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        stringPoint = spider.electricStringPoint;
        yTree = spider.treeBranch.transform.position.y;

        updatingInterval = 1f / fps;
        animationStep = 0;
        animationNumber = textures.Length;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = stringPoint.position;
        render.SetPosition(0, currentPosition);
        render.SetPosition(1, new Vector2(currentPosition.x, yTree));

        if (Time.time > nextUpdatingTime)
        {
            animationStep++;
            render.material.SetTexture("_MainTex", textures[animationStep % animationNumber]);
            nextUpdatingTime = Time.time + updatingInterval;
        }
        
    }
}
