using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);


    // Update is called once per frame
    //lateupdate is for camera use which follows player:
    void LateUpdate()
    {   //Offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;

    }
}
