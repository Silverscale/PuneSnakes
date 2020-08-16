using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFactory : MonoBehaviour
{
    [SerializeField] GameObject HeadPrefab;
    [SerializeField] GameObject BodyPrefab;
    [SerializeField] private Material[] playerMat = default;


    // Start is called before the first frame update
    public GameObject NewHead(int playerID) {
        GameObject newHead = Object.Instantiate<GameObject>(HeadPrefab);
        newHead.GetComponentInChildren<SpriteRenderer>().material = playerMat[playerID];
        playerMat[playerID].color = Player.GetPlayer(playerID).color;
        return newHead;
    }

    public GameObject NewBody(int playerID) {
        GameObject newBody = Object.Instantiate<GameObject>(BodyPrefab);
        newBody.GetComponentInChildren<SpriteRenderer>().material = playerMat[playerID];
        return newBody;
    }

}
