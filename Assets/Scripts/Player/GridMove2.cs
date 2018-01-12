using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove2 : MonoBehaviour {

    private int cellSize = 1;
    public float WalkSpeed = 5.0f;
    public float TurnSpeed = 3.5f;
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
            StartCoroutine(MoveForward());
        }
        if (Input.GetKeyUp("s"))
        {
            StartCoroutine(MoveBackward());
        }
        if (Input.GetKeyUp("a"))
        {
            StartCoroutine(RotateLeft());
        }
        if (Input.GetKeyUp("d"))
        {
            StartCoroutine(RotateRight());
        }

    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(120, 50, 100, 30), "Step Forward"))

            StartCoroutine(MoveForward()); ;

        if (GUI.Button(new Rect(10, 90, 100, 30), "Turn Left"))

            StartCoroutine(RotateLeft());

        if (GUI.Button(new Rect(120, 90, 100, 30), "Step Back"))

            StartCoroutine(MoveBackward());

        if (GUI.Button(new Rect(230, 90, 100, 30), "Turn Right"))
            StartCoroutine(RotateRight());

    }

    IEnumerator MoveForward()
    {
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * cellSize);
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0) {
            walkingSound.Play();
            for (float t=0f;t < 1f; t+= Time.deltaTime * (WalkSpeed / cellSize))
            {
                transform.position = Vector3.Lerp(transform.position, newPos, t);
                yield return new WaitForSeconds(0);
            }
            //transform.Translate(Vector3.forward * cellSize);
        }
    }

    IEnumerator MoveBackward()
    {
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * -cellSize);
        Collider[] hitColliders = Physics.OverlapSphere(newPos, 0.1f);
        if (hitColliders.Length == 0)
        {
            walkingSound.Play();
            for (float t = 0f; t < 1f; t += Time.deltaTime * (WalkSpeed / cellSize))
            {
                transform.position = Vector3.Lerp(transform.position, newPos, t);
                yield return new WaitForSeconds(0);
            }
        }
    }

    IEnumerator RotateLeft()
    {
        var oldRotation = transform.rotation;
        transform.Rotate(0, -90, 0);
        var NewRotation = transform.rotation;

        for (float t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(oldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }
        transform.rotation = NewRotation;
    }

    IEnumerator RotateRight()
    {
        var oldRotation = transform.rotation;
        transform.Rotate(0, 90, 0);
        var NewRotation = transform.rotation;

        for (float t = 0.0f; t <= 1.0f; t += (TurnSpeed * Time.deltaTime))
        {
            transform.rotation = Quaternion.Slerp(oldRotation, NewRotation, t);
            yield return new WaitForSeconds(0);
        }
        transform.rotation = NewRotation;
        //transform.Rotate(0, 90, 0);
    }
}
