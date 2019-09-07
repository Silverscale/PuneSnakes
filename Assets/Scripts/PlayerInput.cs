using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {

    private int playerNumber;
    private Player myPlayer;
    private string inputAxis;
    private FollowTheCongaLine controllerFollowingMe;
    private float stepThisFrame;

    void Start() {
        myPlayer = GetComponentInParent<Player>();
        playerNumber = myPlayer.playerNumber;
        inputAxis = "Player" + playerNumber;
    }

    public void SetControllerFollowingMe(FollowTheCongaLine controller) {
        controllerFollowingMe = controller;
    }

    void FixedUpdate() {
        GetThisFrameStep();
    }

    private void GetThisFrameStep() {
        stepThisFrame = Input.GetAxisRaw(inputAxis);

        if (controllerFollowingMe != null) {
            controllerFollowingMe.AddStep(stepThisFrame);
        }
    }

    public float GetInput() {
        return stepThisFrame;
    }


    //public float GetInput() {
    //    Debug.Log("Reading input from " + inputAxis);
    //    return Input.GetAxisRaw(inputAxis);
    //}
}