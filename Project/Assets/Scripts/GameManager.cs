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

    public float maxFlickerOffTime;
    public float maxFlickerOnTime;
    public GameObject playerLight;
    private GameObject playerObject;

    public bool buttonPressed;

    public TextMeshProUGUI endingText;
    
    public Light endLight;
    private Color endColor = new (1, .48f, .48f, 1);
    public TextMeshProUGUI endText;
    public GameObject endArea;
    public GameObject buttonAreaObjects;

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
        StartCoroutine(PlayerLightOn());
        // Spawn monster
        SpawnMonster();
        // Change the text to reflect winning.
        ChangeText();
        OnAroundButtonObjects();
    }
    
    private void OnAroundButtonObjects() {
        buttonAreaObjects.SetActive(true);
    }

    private void ChangeText()
    {
        endingText.text = "Lockdown Disengaged";
    }

    private IEnumerator PlayerLightOn()
    {
        playerLight.SetActive(true);
        while (true)
        {
            // Flicker Light
            playerLight.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(Random.Range(1, maxFlickerOnTime));
            playerLight.GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(Random.Range(.1f, maxFlickerOffTime));
        }
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
	    Infinadeck.Infinadeck.StopTreadmill();
        SceneManager.LoadScene(0);
    }
}
