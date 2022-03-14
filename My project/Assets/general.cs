using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class general : MonoBehaviour
{
    public static int score1 = 0;
    public static int score2 = 0;
    public GUISkin skin;
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position.x > 10)
        {
            score1++;
            ball.SendMessage("Reset", null, SendMessageOptions.RequireReceiver);
        }
        else if(ball.transform.position.x < -10)
        {
            score2++;
            ball.SendMessage("Reset", null, SendMessageOptions.RequireReceiver);
        }
    }
    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width/2-150, 0, 100, 100), "" + score1);
        GUI.Label(new Rect(Screen.width/2+150, 0, 100, 100), "" + score2);
    }
}
