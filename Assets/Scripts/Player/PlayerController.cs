using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private FieldOfView fov;

        private Vector3 targetPosition;
        private Vector3 direction;

        private Rigidbody2D rigidbody;

        void Start()
        {
            rigidbody = this.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            var mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
            rigidbody.MoveRotation(Quaternion.AngleAxis(angle, Vector3.forward));

            if (Input.GetMouseButton(0))
                Move();

            if (Input.GetMouseButtonUp(0))
                direction = Vector2.zero;

            Vector3 targetPosition = CameraUtils.GetMouseWorldPosition();
            Vector3 aim = (targetPosition - transform.position).normalized;

            fov.SetAimDirection(aim);
            fov.SetOrigin(transform.position);
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