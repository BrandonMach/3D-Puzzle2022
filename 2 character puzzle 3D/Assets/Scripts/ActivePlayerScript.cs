using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerScript : MonoBehaviour
{

    public PlayerMindScript playerMindScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        playerMindScript.ChangePlayer(this.gameObject);
        GetComponent<MovementScript>().enabled = true;
        GetComponent<MovementScript>().IsActivePlayer = true;

    }
}
