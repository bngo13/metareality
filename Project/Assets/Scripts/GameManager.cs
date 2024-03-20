using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainDoor;
    public Light mainDoorLight;
    
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
        mainDoor.SetActive(false); // Animate this is better but just removing it is fine for now
        mainDoorLight.color = Color.green;
        mainDoorLight.intensity = 0.5f;
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
