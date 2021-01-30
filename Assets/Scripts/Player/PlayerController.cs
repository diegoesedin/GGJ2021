using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Vector3 targetPosition;
        private Vector3 direction;

        private Rigidbody2D rigidbody;

        void Start()
        {
            rigidbody = this.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
                Move();

            if (Input.GetMouseButtonUp(0))
                direction = Vector2.zero;
        }

        void FixedUpdate()
        {
            rigidbody.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }

        void SetTargetPosition()
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
        }

        void Move()
        {
            SetTargetPosition();
            direction = (targetPosition - transform.position).normalized;
        }
    }
}