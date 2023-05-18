using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Follower nextInLine;
    //private Queue<Vector2> steps;
    private Queue<TrunkStep> steps;
    [SerializeField] private int stepsBehind = 100;
    private bool following = true;
    public int numberInLine = 0;


    void FixedUpdate()
    {
        if (following) {
            MakeAStep();
            RotateTowardsNextStep();
        }
        if (nextInLine) {
           
            nextInLine.AddStep(transform.position, false);
        }
    }

    private void MakeAStep() {
        //Vector2 nextStep = steps.Dequeue();
        TrunkStep nextStep = steps.Dequeue();
        transform.position = nextStep.stepPosition;
    }
    private void RotateTowardsNextStep() {
        var direction = steps.Peek().stepPosition - (Vector2)transform.position;
        if (direction != Vector2.zero) {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    public void AddStep(Vector2 step, bool high) {
        TrunkStep tempStep = new TrunkStep(step, high);
        steps.Enqueue(tempStep);
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
        steps = new Queue<TrunkStep>();
        for (int i = 0; i < GameMode.BODY_FRAMES_BEHIND; i++) {
            Vector2 newStep = Vector2.Lerp(transform.position, target, (float)i / (float)stepsBehind);
            TrunkStep newTrunkStep = new TrunkStep(newStep, false);
            steps.Enqueue(newTrunkStep);
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

    public Transform GetLastFollowerTransform() {
        Transform position = transform;
        if (nextInLine) {
            position = nextInLine.GetLastFollowerTransform();
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
