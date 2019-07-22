using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bodyChunk;
    private readonly string wallTag = "Obstacle";
    private int playerNumber;
    private Follower follower;

    //private Transform body;

    // Start is called before the first frame update
    void Start()
    {

        //body = GameObject.Instantiate(bodyChunk, gameObject.transform, false).GetComponent<Transform>();
        StartCoroutine(SpawnChunks());
    }

    void FixedUpdate() {
        if (follower) {
            follower.AddStep(transform.position);
        }
    }

    //Para testear el funcionamiento de los followers.
    private IEnumerator SpawnChunks() {
        do {
            yield return new WaitForSeconds(3f);
            Follower newFollower = GameObject.Instantiate(bodyChunk, transform.parent, false).GetComponent<Follower>();
            Debug.Log("Creating new follower");
            if (follower) {
                follower.AddFollower(newFollower);
                Debug.Log("Follower exists, passing it along");
            }
            else {
                follower = newFollower;
                follower.InitializeSteps(transform.position);
                Debug.Log("First follower, assigned and initialized");
            }
        } while (true);
    }

    /*
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag(wallTag))
    {
        gameObject.SetActive(false);
    }
}
*/

}
