using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainDoorLocked;
    public GameObject mainDoorUnlocked;
    
    public GameObject monsterDoor;
    public GameObject monster;

    public GameObject playerLight;

    public bool buttonPressed;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
    }

    public void ButtonPress()
    {
        // Open door
        OpenDoor();
        // Turn on player lights
        OnPlayerLight();
        // Spawn monster
    }

    private void OnPlayerLight()
    {
        // TODO Flicker Light
        playerLight.SetActive(true);
    }

    private void OpenDoor()
    {
        mainDoorLocked.SetActive(false);
        mainDoorUnlocked.SetActive(true);
        buttonPressed = true;
    }

    private void SpawnMonster()
    {
        
    }

    public void Die()
    {
        // TODO
    }
}
