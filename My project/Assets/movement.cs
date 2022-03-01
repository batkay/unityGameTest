using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private KeyCode up = KeyCode.W;
    private KeyCode down = KeyCode.S;
    private int speed = 1;

    private float distance;
    private Vector2 maxY;
    private Vector2 minY;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(Camera.main.transform.position, transform.position); //distance is depth of camera
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance)); //top right of viewport into world coordinates
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        print("max " + maxY + " ");
        print("min "+ minY);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        int velocity = 0;
        // print("update");
        if (Input.GetKeyDown(up))
        {
            print("p");
            velocity += speed;
        }
        if (Input.GetKeyDown(down))
        {
            velocity -= speed;
        }
        //print(velocity);
        position.y += velocity;
        if(position.y > maxY.y)
        {
            position.y = maxY.y;
        }
        else if (position.y < minY.y)
        {
            position.y = minY.y;
        }
        //print(position.y);
        transform.position = position;
    }
}
