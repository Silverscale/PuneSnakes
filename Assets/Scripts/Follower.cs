using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Follower nextInLine;
    private Queue<Vector2> steps;
    [SerializeField] private int stepsBehind = 100;
    private bool following = true;


    void FixedUpdate()
    {
        Vector2 nextStep = steps.Dequeue();
        if (following) {
            transform.position = nextStep;

            if ((Vector3)steps.Peek() - transform.position != Vector3.zero && transform.TransformDirection(Vector3.up) != Vector3.zero)
            { 
                Quaternion rotation = Quaternion.LookRotation
                ((Vector3)steps.Peek() - transform.position, transform.TransformDirection(Vector3.up));
                transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            }
            

            //TODO rotation;
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

    public void InitializeSteps(Vector2 target) {
        steps = new Queue<Vector2>();
        for (int i = 0; i < GameOptions.framesBehind; i++) {
            Vector2 newStep = Vector2.Lerp(transform.position, target, (float)i / (float)stepsBehind);
            //Debug.Log("Adding step: " + newStep);
            steps.Enqueue(newStep);
        }
    }
    public void Stop() {
        following = false;
       // Debug.Log(this.name + " is stopping.");
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
}
