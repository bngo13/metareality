using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainDoorLocked;
    public GameObject mainDoorUnlocked;
    
    public GameObject monsterDoor;
    public GameObject monster;

    public GameObject playerLight;

    public bool buttonPressed;

    public Light endLight;
    public TextMeshProUGUI endText;
    public GameObject endArea;

    private static string LOSS_TEXT = "You Lost :(";
    
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
        endArea.gameObject.SetActive(true);
        buttonPressed = true;
    }

    private void SpawnMonster()
    {
        
    }

    public void Die()
    {
        endText.text = LOSS_TEXT;
        endLight.color = new Color(255, 122, 122);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
