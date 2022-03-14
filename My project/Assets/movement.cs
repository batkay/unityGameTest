using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public float speed = 0.02f;

    private float distance;
    private Vector2 max;
    private Vector2 min;

    private float maxY;
    private float minY;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(Camera.main.transform.position, transform.position); //distance is depth of camera
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance)); //top right of viewport into world coordinates
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        maxY = max.y;
        minY = min.y;
        body = GetComponent<Rigidbody2D>();
        //print("max " + max + " ");
        //print("min "+ min);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = body.transform.position;
        float velocity = 0;
        // print("update");
        if (Input.GetKey(up))
        {
            velocity += speed;
        }
        if (Input.GetKey(down))
        {
            velocity -= speed;
        }
        //print(velocity);
        position.y += velocity;
        var vel = body.velocity;
        vel.y = velocity;
        body.velocity = vel;
        if(position.y > maxY)
        {
            position.y = maxY;
        }
        else if (position.y < minY)
        {
            position.y = minY;
        }
        //print(position.y);
        body.transform.position = position;
    }
}
