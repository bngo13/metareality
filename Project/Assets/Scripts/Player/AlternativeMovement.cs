using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;

public class AlternativeMovement : MonoBehaviour
{
    // Used to make player move slower or faster depending on how hard they swing their hand.
    [SerializeField] private float playerSpeedOffset = 1;

    private Rigidbody playerRigidBody;
    private Camera playerCamera;

    private float leftControllerSpeed = 0f;
    private float rightControllerSpeed = 0f;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void HandSpeedLeft(SteamVR_Behaviour_Pose controllerChange, SteamVR_Input_Sources source)
    {
        if (source != SteamVR_Input_Sources.LeftHand)
        {
            return;
        }

        var controllerVelocity = controllerChange.GetVelocity().magnitude;
        leftControllerSpeed = controllerVelocity;
        Debug.Log("Left Controller Speed: " + leftControllerSpeed);
    }

    public void HandSpeedRight(SteamVR_Behaviour_Pose controllerChange, SteamVR_Input_Sources source)
    {
        if (source != SteamVR_Input_Sources.RightHand)
        {
            return;
        }

        var controllerVelocity = controllerChange.GetVelocity().magnitude;
        rightControllerSpeed = controllerVelocity;
        Debug.Log("Right Controller Speed: " + rightControllerSpeed);
    }

    private void Update()
    {
        var controllerSpeed = (leftControllerSpeed + rightControllerSpeed) / 2;
        Debug.Log("Average Controller Speed: " + controllerSpeed);
        if (controllerSpeed < 1)
        {
            return;
        }
        var forceVector = playerCamera.transform.forward * controllerSpeed;
        forceVector.y = 0;
        playerRigidBody.velocity = forceVector * playerSpeedOffset;
    }
}
