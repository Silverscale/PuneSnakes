using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Follower nextInLine;
    private Queue<Vector2> steps;
    [SerializeField] private int stepsBehind = 100;


    void FixedUpdate()
    {
        Vector2 nextStep = steps.Dequeue();
        transform.position = nextStep;
        //transform.LookAt(steps.Peek());
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
        for (int i = 0; i < stepsBehind; i++) {
            Vector2 newStep = Vector2.Lerp(transform.position, target, (float)i / (float)stepsBehind);
            Debug.Log("Adding step: " + newStep);
            steps.Enqueue(newStep);
        }
    }
}
