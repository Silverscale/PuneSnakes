using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    [SerializeField] private Player playerPrefab = default;
    [SerializeField] private SnakeHead snakePrefab = default;
    [SerializeField] private Transform[] spawnPoint = default;

    //public List<Player> playerList;

	void Start ()
    {
        //Clear the list of players
        Player.ClearPlayerList();
        for (int i = 0; i < GameOptions.players; i++)
        {
            //Create and setup the starting elements for a match
            Player newPlayer = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Player>();
            SnakeHead newSnake = Object.Instantiate<GameObject>(snakePrefab.gameObject).GetComponent<SnakeHead>();
            
            //La serpiente queda como hijo del Player, para que quede mas ordenada la escena.
            //Ademas, hace que sea mas facil para los componentes de la serpiente encontrar su player,
            //usando GetComponentInParent<Player>();
            newSnake.transform.SetParent(newPlayer.transform);

            //WARNING:  Referencia circular, hay que encontrar una forma mejor de hacer esto.
            //          SnakeHead deberia tener la referencia a player, pero NO player a SnakeHead.
            //          Esto permitiria reusar la clase Player en otros modos de juego.
            newSnake.SetPlayer(newPlayer);
            newPlayer.SetSnake(newSnake);


            //Position and scale the snakes for the game start
            Transform playerTransform = newPlayer.gameObject.GetComponent<Transform>();
            playerTransform.localScale = Vector3.one * GameOptions.snakeScale;
            playerTransform.position = spawnPoint[i].position;
            playerTransform.rotation = spawnPoint[i].rotation;

            //Disable the players while they wait for the round to start
            newPlayer.Disable();
        }
        SoundManager.Instance.PlayGameMusic();
    }
}
