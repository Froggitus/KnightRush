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
    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("init");
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float xTranslation = Input.GetAxis("Horizontal") * speed;
        float yTranslation = Input.GetAxis("Vertical") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        xTranslation *= Time.deltaTime;
        yTranslation *= Time.deltaTime;

        transform.Translate(xTranslation, 0, 0);
        transform.Translate(0, yTranslation, 0);
    }
}
