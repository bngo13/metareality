using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLights : MonoBehaviour
{
    public float lightFadeInterval = 1e-10f;
    public float lightChangeAmount = 0.02f;

    
    private Light objectLight;
    private IEnumerator lightFade;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        objectLight = GetComponent<Light>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        lightFade = FadeLights();
        StartCoroutine(lightFade);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.buttonPressed) {
            KillLights();
            Destroy(this);
        }
    }

    public void KillLights() {
        StopCoroutine(lightFade);
        FlickerLights();
    }

    private void FlickerLights() {
        // TODO Flicker the lights
        objectLight.intensity = 0f;
    }

    private IEnumerator FadeLights() {
        while (true) {
            if (objectLight.intensity > 1f || objectLight.intensity <= 0f) {
                lightChangeAmount *= -1;
            }

            objectLight.intensity += lightChangeAmount;

            yield return new WaitForSeconds(lightFadeInterval);
        }
    }
}
