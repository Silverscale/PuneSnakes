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
    private Transform tail;

    private bool onAir;
    private int airTime;
    [SerializeField] private int jumpLength = 100;

    void Awake() {
        myMovement = GetComponent<SnakeMovement>();
        tail = transform;
        onAir = false;
        
    }

    void FixedUpdate() {

        //Jumpy stuff horrible
        airTime--;
        if (airTime <=0)
        {
            onAir = false;
            bool isJumping = myMovement.IsJumping();
            if (isJumping)
            {
                Jump();
            }

        }
        
        //
        if (follower) {
            follower.AddStep(transform.position, false);//aca va IsJumping pero veremos
        }

    }

    public void AddFollower(Follower theFollower) {
        followerCount++;
        theFollower.numberInLine = followerCount;
        tail = theFollower.transform;
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
                {
                    if (!onAir) //only collide if down
                    this.Kill();
                }
                  
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

    public void Jump()
    {
        Debug.Log("YOU JUMPED");
            airTime = jumpLength;
        onAir = true;
        

    }
    public Transform TailTransform() {
        return tail;
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
        if (follower) {
            follower.StopAll();
        }
    }

    public void SelfDestruct() {
        IsActive = false; //this should stop the snake from expanding before being destroyed, which can lead to a bug
        if (follower) {
            follower.SelfDestruct();
        }
        Destroy(gameObject);
    }
}
