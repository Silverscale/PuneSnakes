using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyChunk : MonoBehaviour
{
    protected SnakeBodyChunk nextInLine;
    public SnakeMovement SnakeMovement { get; protected set; }

    protected void Awake() {
        SnakeMovement = GetComponent<SnakeMovement>();
    }

    public void AddBodyChunk(SnakeBodyChunk theFollower) {
        if (nextInLine) {
            nextInLine.AddBodyChunk(theFollower);
        }
        else {
            nextInLine = theFollower;
            ISnakeController myController = GetComponent<ISnakeController>();
            ISnakeController followerController = theFollower.GetComponent<ISnakeController>();
            myController.SetControllerFollowingMe((FollowTheCongaLine)followerController);
            //nextInLine.InitializeSteps(transform.position);
        }
    }

    public Vector2 TailPosition() {
        Vector2 position = transform.position;
        if (nextInLine) {
            position = nextInLine.TailPosition();
        }
        return position;
    }

    virtual public void Go() {
        SnakeMovement.Resume();
        if (nextInLine) {
            nextInLine.Go();
        }
    }

    virtual public void Wait() {
        SnakeMovement.Stop();
        if (nextInLine) {
            nextInLine.Wait();
        }
    }

    public void SelfDestruct() {
        if (nextInLine) {
            nextInLine.SelfDestruct();
        }
        Destroy(gameObject);
    }
}
