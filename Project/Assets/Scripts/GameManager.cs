using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainDoorLocked;
    public GameObject mainDoorUnlocked;
    
    public GameObject monsterDoor;
    public GameObject monster;

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
        // Turn off lights
        // Spawn monster
    }

    private void LightsOut()
    {
        
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
