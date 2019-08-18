using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    [SerializeField] private SnakeHead snakePrefab = default;
    [SerializeField] private Transform[] spawnPoint = default;

    //public List<Player> playerList;

	void Start ()
    {
        //Clear the list of players
        //Player.ClearPlayerList();
        for (int i = 0; i < GameOptions.players; i++)
        {
            //Create and setup the starting elements for a match
            Player player = Player.GetPlayer(i);
            SnakeHead newSnake = Object.Instantiate<GameObject>(snakePrefab.gameObject).GetComponent<SnakeHead>();
            
            //La serpiente queda como hijo del Player, para que quede mas ordenada la escena.
            //Ademas, hace que sea mas facil para los componentes de la serpiente encontrar su player,
            //usando GetComponentInParent<Player>();
            newSnake.transform.SetParent(player.transform);

            //WARNING:  Referencia circular, hay que encontrar una forma mejor de hacer esto.
            //          SnakeHead deberia tener la referencia a player, pero NO player a SnakeHead.
            //          Esto permitiria reusar la clase Player en otros modos de juego.
            newSnake.SetPlayer(player);
            player.SetSnake(newSnake);


            //Position and scale the snakes for the game start
            Transform snakeTransform = newSnake.gameObject.GetComponent<Transform>();
            snakeTransform.localScale = Vector3.one * GameOptions.snakeScale;
            snakeTransform.position = spawnPoint[i].position;
            snakeTransform.rotation = spawnPoint[i].rotation;

            //Disable the players while they wait for the round to start
            player.Disable();
        }
        SoundManager.Instance.PlayGameMusic();
    }
}
