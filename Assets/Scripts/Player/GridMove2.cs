using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove2 : MonoBehaviour {

    private int cellSize = 1;
    private AudioSource walkingSound;

    // Use this for initialization
    void Start()
    {
        walkingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("w"))
        {
            MoveForward();
        }
        if (Input.GetKeyUp("s"))
        {
            MoveBackward();
        }
        if (Input.GetKeyUp("a"))
        {
            RotateLeft();
        }
        if (Input.GetKeyUp("d"))
        {
            RotateRight();
        }

    }

    private void MoveForward()
    {
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward) * cellSize;
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0) {
            walkingSound.Play();
            transform.Translate(Vector3.forward * cellSize);
        }
    }

    private void MoveBackward()
    {
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward) * -cellSize;
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0) { transform.Translate(Vector3.forward * -cellSize); }
    }

    private void RotateLeft()
    {
        transform.Rotate(0, -90, 0);
    }

    private void RotateRight()
    {
        transform.Rotate(0, 90, 0);
    }
}
