using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float dampTime = 0.15f;

        private Camera camera;
        private Vector3 velocity = Vector3.zero;

        void Start()
        {
            camera = GetComponent<Camera>();
        }


        void FixedUpdate()
        {
            if (player)
            {
                Vector3 delta = player.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -10));
                Vector3 destination = transform.position + delta;
                destination.z = -10;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }
    }
}
