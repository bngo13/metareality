using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class AlternativeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private GameObject infinaDeck;

    private Rigidbody playerRigidBody;
    
    // Start is called before the first frame update
    void Awake()
    {
        //enabled = !infinaDeck.activeSelf;
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        FrontBack();
        LeftRight();

        if (!Input.anyKey)
        {
            playerRigidBody.velocity = new UnityEngine.Vector3(0, playerRigidBody.velocity.y, 0);
        }
    }

    private void FrontBack()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidBody.velocity = transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S)) {
            playerRigidBody.velocity = -transform.forward * movementSpeed;
        }
    }

    private void LeftRight()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidBody.velocity = -transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidBody.velocity = transform.right * movementSpeed;
        }
    }
}
