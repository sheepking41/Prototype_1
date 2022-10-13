using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float horsePower = 0f;
    [SerializeField] private float turnSpeed = 30.0f;

    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }


    // Update is called once per frame
    void FixedUpdate() //fixedupdate is useful for doing movement and physics, called b4 Update 
    {
        //This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // We will move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            //We turn the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); //for kph, change 2.237 to 3.6
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }



    }

    bool IsOnGround()
    {
        
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        } 

        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }





}
