using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBodyChunk {

    public bool IsAlive { get; private set; } = true;
    public bool IsActive { get; private set; } = false;
    private Player myPlayer;

    void OnTriggerEnter2D(Collider2D col) {
        //Collided with something
        if (IsAlive) {
            //only process collisions if ImAlive
            if (nextInLine) {
                //only kill if im not colliding with my follower
                if (col.gameObject != nextInLine.gameObject)
                    this.Kill();
            }
            else {
                //If I dont have a follower, any collision kills
                this.Kill();
            }
        }
    }
    public void SetPlayer(Player player) {
        myPlayer = player;
    }

    public void Kill() {
        if (IsAlive) {
            SnakeMovement.Stop();
            if (nextInLine) {
                //nextInLine.StopAll();
                Wait();
            }
            IsAlive = false;
            IsActive = false;
            myPlayer.Disable();
        }
    }

    public override void Go() {
        IsActive = true;
        base.Go();
    }

    public override void Wait() {
        IsActive = false;
        base.Wait();
    }
}
