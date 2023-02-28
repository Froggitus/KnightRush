using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemy : MonoBehaviour
{
    private float xInput = 1;
    private float yInput = 0;
    private float speed = 2.0f;
    private float right = -1;
    private float up = 1;
    private float step = 0.1f;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        counter++;
        if (counter == 100)
        {
            counter = 0;
            xInput += step * right;
            yInput += step * up;
        }

        if (xInput < -0.99f) right = 1;
        if (xInput > 0.99) right = -1;
        if (yInput < -0.99f) up = 1;
        if (yInput > 0.99) up = -1;

        float xTranslation = xInput * speed;
        float yTranslation = yInput * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        xTranslation *= Time.deltaTime;
        yTranslation *= Time.deltaTime;

        float xPos = transform.position.x + xTranslation;
        float yPos = transform.position.y + yTranslation;

        Vector3 newPos = new Vector3(xPos, yPos, 0.0f);
        transform.SetPositionAndRotation(newPos, transform.rotation);
    }
}
