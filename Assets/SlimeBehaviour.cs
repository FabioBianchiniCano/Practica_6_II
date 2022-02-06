using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SlimeBehaviour : MonoBehaviour
{
    private Animator anim;
    private float lastCompass;
    private bool camLock = false;

    public float speed = 2.0f;

    void Start()
    {
        Input.compass.enabled = true;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0) {
            if (camLock) {
                camLock = false;
            } else {
                camLock = true;
            }
        }

        if (!camLock) {
            float currentMagneticHeading = (float)Math.Round(Input.compass.magneticHeading, 1);
            transform.localRotation = Quaternion.Euler(0, currentMagneticHeading, 0);
        } else {
            Vector3 dir = transform.forward * -1;
            if (Input.acceleration.sqrMagnitude > 5) {
                anim.speed = Input.acceleration.sqrMagnitude / 10;
                anim.Play("RunFWD", 0, 0);
                dir *= Time.deltaTime;
                dir *= Input.acceleration.sqrMagnitude;
                transform.Translate(dir);
            }
        }

    }
}
