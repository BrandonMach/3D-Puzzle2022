using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMindScript : MonoBehaviour
{
    public GameObject[] players;
    static public GameObject currentPlayer;




    void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<MovementScript>().enabled = true; // Is true so that all player character have gravity and not floating/ stuck in the air
        }

        currentPlayer = players[0];
        // currentPlayer.GetComponent<MovementScript>().IsActivePlayer = true;

    }

    // Update is called once per frame
    void Update()
    {


        foreach (GameObject player in players)
        {
            if (player != currentPlayer && player.GetComponent<MovementScript>().GetCharacterController.isGrounded)
            {
                player.GetComponent<MovementScript>().enabled = false;  //Prevents non active player from moving
                player.GetComponent<MovementScript>().IsActivePlayer = false;  // Lets the selected player move (Horizontal and vertivcal)
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            ChangePlayer(players[0]);
            players[0].GetComponent<MovementScript>().enabled = true;  //Prevents non active player from moving
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangePlayer(players[1]);
            players[1].GetComponent<MovementScript>().enabled = true;  //Prevents non active player from moving
        }

        if (currentPlayer == players[1])
        {
            Debug.LogError("Controlling player 2");

        }
    }

    public void ChangePlayer(GameObject player)
    {
        currentPlayer.GetComponent<MovementScript>().IsActivePlayer = false;
        currentPlayer = player;
        currentPlayer.GetComponent<MovementScript>().IsActivePlayer = true;
    }
}
