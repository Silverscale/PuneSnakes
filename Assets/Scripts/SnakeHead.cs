using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour {
    private Follower follower;
    public bool IsAlive { get; private set; } = true;
    public bool IsActive { get; private set; } = false;
    private SnakeMovement myMovement;
    private Player myPlayer;
    public int followerCount { get; private set; } = 0;

    void Awake() {
        myMovement = GetComponent<SnakeMovement>();
    }

    void FixedUpdate() {
        if (follower) {
            follower.AddStep(transform.position);
        }
    }

    public void AddFollower(Follower theFollower) {
        followerCount++;
        theFollower.numberInLine = followerCount;
        if (follower) {
            follower.AddFollower(theFollower);
        }
        else {
            follower = theFollower;
            follower.InitializeSteps(transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Collided with something
        if (IsAlive) {
            //only process collisions if ImAlive
            if (follower) {
                //only kill if im not colliding with my follower
                if (col.gameObject != follower.gameObject)
                    this.Kill();
            }
            else {
                //If I dont have a follower, any collision kills
                this.Kill();
            }
        } 
    }
    public void Kill() {
        if (IsAlive) {
            myMovement.Stop();
            if (follower) {
                follower.StopAll();
            }
            IsAlive = false;
            IsActive = false;
            myPlayer.Disable();
        }
    }

    public Vector2 TailPosition() {
        Vector2 position = transform.position;
        if (follower) {
            position = follower.GetLastFollowerPosition();
        }
        return position;
    }

    public void SetPlayer(Player player) {
        myPlayer = player;
    }

    public void Go() {
        IsActive = true;
        myMovement.Resume();
    }

    public void Wait() {
        myMovement.Stop();
        IsActive = false;
    }

    public void SelfDestruct() {
        IsActive = false; //this should stop the snake from expanding before being destroyed, which can lead to a bug
        if (follower) {
            follower.SelfDestruct();
        }
        Destroy(gameObject);
    }
}
