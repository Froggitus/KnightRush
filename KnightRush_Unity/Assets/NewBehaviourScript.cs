using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
 */
public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject test_enemy;
    private GameObject enemy_spawned = null;
    public bool spawned = false;

    // Start is called before the first frame update
    void Start() {
        // Debug.Log("init");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        spawnTriangle();
    }

    void move()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float xTranslation = Input.GetAxis("Horizontal") * speed;
        float yTranslation = Input.GetAxis("Vertical") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        xTranslation *= Time.deltaTime;
        yTranslation *= Time.deltaTime;

        float xPos = transform.position.x + xTranslation;
        float yPos = transform.position.y + yTranslation;

        if (xPos > 10.2f) xPos = 10.2f;
        if (xPos < -10.2f) xPos = -10.2f;
        if (yPos > 4.5f) yPos = 4.5f;
        if (yPos < -4.5f) yPos = -4.5f;

        Vector3 newPos = new Vector3(xPos, yPos, 0.0f);
        transform.SetPositionAndRotation(newPos, transform.rotation);
    }

    void spawnTriangle()
    {
        if (!spawned)
        {
            if (transform.position.x > 2 && transform.position.y > 2)
            {
                enemy_spawned = Instantiate(test_enemy, new Vector3(0, 0, 0), Quaternion.identity);
                spawned = true;
            }
        } else
        {
            if (transform.position.x < -2 && transform.position.y < -2)
            {
                DestroyImmediate(enemy_spawned);
                spawned = false;
            }
        }
    }
}
