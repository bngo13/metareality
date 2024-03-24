using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainDoorLocked;
    public GameObject mainDoorUnlocked;
    
    public List<GameObject> monsterDoor;
    public GameObject monster;

    public GameObject playerLight;
    private GameObject playerObject;
    public InfinadeckCore deckCore;

    public bool buttonPressed;

    public Light endLight;
    private Color endColor = new (1, .48f, .48f, 1);
    public TextMeshProUGUI endText;
    public GameObject endArea;

    private GameObject gameEnd;
    
    private static string LOSS_TEXT = "You Lost :(";
    
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        gameEnd = GameObject.FindGameObjectWithTag("GameEnd");
        buttonPressed = false;
    }

    public void ButtonPress()
    {
        // Open door
        OpenDoor();
        // Turn on player lights
        OnPlayerLight();
        // Spawn monster
        SpawnMonster();
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
        foreach (var wall in monsterDoor)
        {
            wall.SetActive(false);
        }
    }

    private void Update()
    {
        
    }

    public void SetEndArea(bool status)
    {
        endArea.SetActive(status);
    }

    public void Die()
    {
        endText.text = LOSS_TEXT;
        endLight.color = endColor;
        playerObject.transform.position = gameEnd.transform.position;
        mainDoorLocked.SetActive(true);
        mainDoorUnlocked.SetActive(false);
    }

    public void Restart()
    {
        // There's more we can do with Infinadeck.Infinadeck
        SceneManager.LoadScene(0);
    }
}
