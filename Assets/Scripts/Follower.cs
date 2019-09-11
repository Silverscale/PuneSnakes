using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Follower nextInLine;
    private Queue<Vector2> steps;
    [SerializeField] private int stepsBehind = 100;
    private bool following = true;
    public int numberInLine = 0;


    void FixedUpdate()
    {
        if (following) {
            Vector2 nextStep = steps.Dequeue();
            transform.position = nextStep;

            if ((Vector3)steps.Peek() - transform.position != Vector3.zero && transform.TransformDirection(Vector3.up) != Vector3.zero)
            { 
                Quaternion rotation = Quaternion.LookRotation
                ((Vector3)steps.Peek() - transform.position, transform.TransformDirection(Vector3.up));
                transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            }
        }

        if (nextInLine) {
            nextInLine.AddStep(transform.position);
        }
    }

    public void AddStep(Vector2 step) {
        steps.Enqueue(step);
    }

    public void AddFollower(Follower theFollower) {
        if (nextInLine) {
            nextInLine.AddFollower(theFollower);
        }
        else {
            nextInLine = theFollower;
            nextInLine.InitializeSteps(transform.position);
        }
    }
    private Vector2 TailPosition() {
        Vector2 position = transform.position;
        if (nextInLine) {
            position = nextInLine.GetLastFollowerPosition();
        }
        return position;
    }

    public void InitializeSteps(Vector2 target) {
        steps = new Queue<Vector2>();
        for (int i = 0; i < GameOptions.framesBehind; i++) {
            Vector2 newStep = Vector2.Lerp(transform.position, target, (float)i / (float)stepsBehind);
            steps.Enqueue(newStep);
        }
    }
    public void Stop() {
        following = false;
    }
    public void StopAll() {
        Stop();
        if (nextInLine) {
            nextInLine.StopAll();
        }
    }

    public Vector2 GetLastFollowerPosition() {
        Vector2 position = new Vector2();
        if (nextInLine) {
            position = nextInLine.GetLastFollowerPosition();
        }
        else {
            position = transform.position;
        }
        return position;
    }

    public void SelfDestruct() {
        if (nextInLine) {
            nextInLine.SelfDestruct();
        }
        Destroy(gameObject);
    }
}
