using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        gameManager.SetEndArea(true);
    }
    
    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        gameManager.SetEndArea(false);
    }
}
