using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    public GameObject buttonObject;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    private GameObject interactable;
    private AudioSource sound;
    private bool isPressed;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) return;

        buttonObject.transform.localPosition = new Vector3(0, 0.003f, 0);
        interactable = other.gameObject;
        onPress.Invoke();
        //sound.Play();
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != interactable) return;

        buttonObject.transform.localPosition = new Vector3(0, 0.25f, 0);
        isPressed = false;
        
        onRelease.Invoke();
    }
}
