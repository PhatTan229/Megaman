using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderSmallSpider : MonoBehaviour
{
    public Transform head;
    public Transform foot;
    public Rigidbody2D rigid;
    public void OnValidate() => rigid = GetComponent<Rigidbody2D>();
    public void Jump(int xForce, int yForce) => rigid.AddForce(new Vector2(xForce, yForce));

    private void OnBecameInvisible() => Destroy(gameObject);

}
