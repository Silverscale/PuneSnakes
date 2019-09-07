using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheCongaLine : MonoBehaviour, ISnakeController
{
    private Queue<float> steps;
    private bool following = false;
    private FollowTheCongaLine controllerFollowingMe;
    private float stepThisFrame;
    private int framesCounter;
    private bool justSpawned = true;

    void Awake() {
        Initialize();
    }

    private void Initialize() {
        steps = new Queue<float>();
        framesCounter = GameOptions.framesBehind;
    }


    //Set the controller of the bodyPart that follows this one, so we can pass the inputs to it
    public void SetControllerFollowingMe(FollowTheCongaLine controller) {
        controllerFollowingMe = controller;
    }

    void FixedUpdate() {
        CheckIfIShouldStartMoving();
        GetThisFrameStep();
    }

    private void CheckIfIShouldStartMoving() {
        if (!following && justSpawned && framesCounter == 0) {
            following = true;
            justSpawned = false;
        }
        else if (framesCounter > 0){
            framesCounter--;
        }
    }

    private void GetThisFrameStep() {
        if (following) {
            stepThisFrame = steps.Dequeue();

            if (controllerFollowingMe != null) {
                controllerFollowingMe.AddStep(stepThisFrame);
            }
        }
        else {
            stepThisFrame = 0f;
        }
    }

    public void AddStep(float step) {
        steps.Enqueue(step);
    }

    public float GetInput() {
        float input = 0f;
        if (following) {
            input = stepThisFrame;
        }
        return input;
    }
}
