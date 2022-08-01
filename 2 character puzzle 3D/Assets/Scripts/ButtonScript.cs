using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{


    public GameObject[] players;
    CharacterController characterController;

    [Header ("ObjectToMove")]
    [SerializeField]
    GameObject bridge;
    bool activated;
    Rigidbody bridgeRb;
    void Start()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        bridgeRb = bridge.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player") && !activated)
        {
            Debug.Log("Button");


            bridgeRb.AddForce(0,- 30f, 0);
            activated = true;
        }

    }
}
