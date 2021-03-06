using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 0.1f;
    private float angularSpeed = 1f;
    private float rx=0f,ry;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;
        // simple motion
        // transform.Translate(new Vector3(0, 0, 0.1f));

        // mouse input
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        ry = transform.localEulerAngles.y+ Input.GetAxis("Mouse X") * angularSpeed;

        transform.localEulerAngles = new Vector3(rx, ry, 0);
        // keyboard input
        dx = Input.GetAxis("Horizontal")*speed;
        dz = Input.GetAxis("Vertical")*speed;
        Vector3 motion = new Vector3(dx, 0, dz);
        motion = transform.TransformDirection(motion); // now in Global coordinates
        controller.Move(motion);
    }
}
