using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollision : MonoBehaviour {

    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Game Over.");
        }
    }
}
