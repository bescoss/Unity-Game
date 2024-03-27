using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Fog : MonoBehaviour
{
    public Transform player; // The target to follow (e.g., the player)


    void Update()
    {
        FogMovement();
    }

    void FogMovement()
    {
        if (player != null)
        {
            // Calculate the target z position for the fog
            float targetZ = player.position.z + 300f;

            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
            transform.position = newPosition;
        }
    }
}
