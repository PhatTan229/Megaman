using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class ProjectileMotion
{
    public static float gravity = 9.81f;
    public static float GetVelocityByOtherVelocity(float otherVelocity, float distance)
    {
        return 1f / 2 * ProjectileMotion.gravity * distance / otherVelocity;
    }
    public static float GetFxFromFy(float Fy, float distance)
    {
        var vy = (Fy - ProjectileMotion.gravity) * Time.fixedDeltaTime;
        var vx = GetVelocityByOtherVelocity(vy, distance);
        var Fx = vx / Time.fixedDeltaTime;
        return Fx;
    }
}
public class Test : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rigid;
    public Transform target;

    private Vector2 direction;
    private float xForce;
    private float lastVelocity;

    private void OnValidate()
    {
        rigid = GetComponent<Rigidbody2D>();
        direction = target.position - transform.position;

    }
    private void Update()
    {
        //transform.Translate(speed * Time.deltaTime * direction.normalized);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (transform.position == target.position) Debug.Log("hit");

        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


}
