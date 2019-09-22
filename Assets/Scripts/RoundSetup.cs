using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSetup : MonoBehaviour {

    [SerializeField] private SnakeHead snakePrefab = default;
    [SerializeField] private Transform[] spawnPoint = default;

    //public List<Player> playerList;

	void Start ()
    {
        //for (int i = 0; i < GameOptions.players; i++)
        //{
        //    //Create and setup the starting elements for a match
        //    Player player = Player.GetPlayer(i);
        //    SnakeHead newSnake = Object.Instantiate<GameObject>(snakePrefab.gameObject).GetComponent<SnakeHead>();
        //    player.SetAsActive();

        //    //La serpiente queda como hijo del Player, para que quede mas ordenada la escena.
        //    //Ademas, hace que sea mas facil para los componentes de la serpiente encontrar su player,
        //    //usando GetComponentInParent<Player>();
        //    newSnake.transform.SetParent(player.transform);

        //    newSnake.SetPlayer(player);

        //    //Position and scale the snakes for the game start
        //    Transform snakeTransform = newSnake.gameObject.GetComponent<Transform>();
        //    snakeTransform.localScale = Vector3.one * GameOptions.snakeScale;
        //    snakeTransform.position = spawnPoint[i].position;
        //    snakeTransform.rotation = spawnPoint[i].rotation;

        //    //Disable the players while they wait for the round to start
        //    //player.Disable();
        //    newSnake.Wait();
        //}
        foreach (var player in Player.GetList()) {
            //Create and setup the starting elements for a match
            SnakeHead newSnake = Object.Instantiate<GameObject>(snakePrefab.gameObject).GetComponent<SnakeHead>();
            player.SetAsActive();

            //La serpiente queda como hijo del Player, para que quede mas ordenada la escena.
            //Ademas, hace que sea mas facil para los componentes de la serpiente encontrar su player,
            //usando GetComponentInParent<Player>();
            newSnake.transform.SetParent(player.transform);

            newSnake.SetPlayer(player);

            //Position and scale the snakes for the game start
            Transform snakeTransform = newSnake.gameObject.GetComponent<Transform>();
            snakeTransform.localScale = Vector3.one * GameOptions.snakeScale;
            snakeTransform.position = spawnPoint[player.playerNumber].position;
            snakeTransform.rotation = spawnPoint[player.playerNumber].rotation;

            //Disable the players while they wait for the round to start
            //player.Disable();
            newSnake.Wait();

        }

        SoundManager.Instance.PlayGameMusic();

    }

}
