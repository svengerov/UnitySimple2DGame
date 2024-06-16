using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 camera_position;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<Hero>().transform;

        }
    }
        private void Update()
        {
            camera_position = player.position;
            camera_position.z = -10f;
            
            transform.position = Vector3.Lerp(transform.position, camera_position, Time.deltaTime);
        }
    }

