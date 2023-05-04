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
        
        newHead.GetComponentInChildren<SnakeMaterialPicker>().Construct(this, playerID);
        //newHead.GetComponentInChildren<SpriteRenderer>().material = playerMat[playerID];
        //playerMat[playerID].color = Player.GetPlayer(playerID).color;
        
        return newHead;
    }

    public GameObject NewBody(int playerID, int numberInLine) {
        GameObject newBody = Object.Instantiate<GameObject>(BodyPrefab);

        newBody.GetComponentInChildren<SnakeMaterialPicker>().Construct(this, playerID);
        //newBody.GetComponentInChildren<SpriteRenderer>().material = playerMat[playerID];

        foreach (var item in newBody.GetComponentsInChildren<SetSpriteLayer>()) {
            item.SetNumberInLine(numberInLine);
        }
        return newBody;
    }

    public Material GetMaterial(int playerID) {
        return playerMat[playerID];
    }

}
