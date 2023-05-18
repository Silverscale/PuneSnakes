﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSetup : MonoBehaviour {

    //[SerializeField] private SnakeHead snakePrefab = default;

    [SerializeField] private Transform[] spawnPoint = default;

	void Start ()
    {
        SnakeFactory factory = FindObjectOfType<SnakeFactory>();

        foreach (var player in Player.GetFullList()) {
            //Create and setup the starting elements for a match
            SnakeHead newSnake = factory.NewHead(player.idNumber).GetComponent<SnakeHead>();
            //SnakeHead newSnake = Object.Instantiate<GameObject>(snakePrefab.gameObject).GetComponent<SnakeHead>();
            player.SetAsActive();

            //La serpiente queda como hijo del Player, para que quede mas ordenada la escena.
            //Ademas, hace que sea mas facil para los componentes de la serpiente encontrar su player,
            //usando GetComponentInParent<Player>();
            newSnake.transform.SetParent(player.transform);

            newSnake.SetPlayer(player);

            //Position and scale the snakes for the game start
            Transform snakeTransform = newSnake.gameObject.GetComponent<Transform>();
            snakeTransform.localScale = Vector3.one * GameMode.SNAKE_SCALE;
            snakeTransform.position = spawnPoint[player.idNumber].position;
            snakeTransform.rotation = spawnPoint[player.idNumber].rotation;

            //Disable the players while they wait for the round to start
            //player.Disable();
            newSnake.Wait();

        }

        //SoundManager.Instance.PlayGameMusic();

    }

}