using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        float random1 = Random.Range(1, 4);
        float random2 = Random.Range(0, 3);
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(random1, random2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print("collide");
        body.velocity = -body.velocity;
    }
}
