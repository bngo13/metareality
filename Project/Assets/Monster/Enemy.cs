using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private GameManager gameManager;

    //Sounds and Animation
    public AudioSource breathSource;
    public AudioSource runSource;
    public AudioSource roarSource;
    public Animator animator;

    public float enemySpeedPadding = 0;
    private float enemySpeed;

    private void Awake()
    {
        // Get all components
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
        // Set variables
        enemySpeed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        // Get player speed
        float rawPlayerSpeed = player.GetComponent<Rigidbody>().velocity.magnitude;

        // Enemy is the average of the player speed
        if (enemySpeed == 0)
        {
            enemySpeed = rawPlayerSpeed;
        }
        enemySpeed = Math.Max(enemySpeed, (enemySpeed + rawPlayerSpeed) / 2);
        agent.speed = enemySpeed * enemySpeedPadding;
        //FileLogger.LogData($"Enemy Speed: {enemySpeed}");

        if (gameManager.buttonPressed) Chase(); else StayInPlace();
    }

    private void StayInPlace()
    {
        ToggleSounds(true);
        animator.speed = 0;
        agent.speed = 0;
    }

    private void Chase()
    {
        animator.speed = .75f;
        ToggleSounds(false);
        animator.SetBool("Running", true);
        agent.SetDestination(player.transform.position);
    }

    private void ToggleSounds(bool isStill)
    {
        
        breathSource.enabled = isStill;
        
        runSource.enabled = !isStill;
        roarSource.enabled = !isStill;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        gameManager.Die();
        Destroy(gameObject);
    }

}
