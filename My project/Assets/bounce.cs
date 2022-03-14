using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        float random1 = Random.Range(3, 5);
        float random2 = Random.Range(1, 4);
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(random1, random2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = body.velocity;
        if(Mathf.Abs(vel.x) <= 3)
        {
            vel.x += vel.x / 4.0f;
        }
        body.velocity = vel;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print("collide");
        // body.velocity = -body.velocity;
        ContactPoint2D[] points = new ContactPoint2D[2];
        collision.GetContacts(points);
        Vector2 vel = body.velocity;
        //print(collision.collider.attachedRigidbody.velocity.y);
        // Assumption works because probably hitting things at right angles
        if (Mathf.Abs(points[0].point.x - body.position.x) > 0.1)
        {
            vel.x = -vel.x - Mathf.Sign(vel.x) * Mathf.Abs(collision.collider.attachedRigidbody.velocity.y*100);
            vel.y = vel.y+ Random.Range(-2, 2);
        }
        if (Mathf.Abs(points[0].point.y - body.position.y) > 0.1)
        {
            vel.y = -vel.y;
            vel.x = vel.x + Random.Range(-2, 2);
        }
        body.velocity = vel;

    }
    private void Reset()
    {
        body.transform.position = new Vector2(0, 0);
        float random1 = Random.Range(3, 5);
        float random2 = Random.Range(1, 4);
        body.velocity = new Vector2(random1, random2);
    }
}
