using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IPlayerController
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        private Rigidbody2D Rb => GetComponent<Rigidbody2D>();
        private Transform transform;

        public bool IsGrounded { get; set; }
        private void Awake()
        {
            this.transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            CheckForInput();
            CheckForActionInput();
        }


        private void CheckForInput()
        {
            if (Input.GetAxis("Horizontal") < 0.0f || Input.GetAxis("Horizontal") > 0.0f)
            {
                var dir = Input.GetAxis("Horizontal");
                transform.Translate(new Vector3(dir * (moveSpeed * Time.fixedDeltaTime),0,0));
            }
        }

        private void CheckForActionInput()
        {
            if (Input.GetAxis("Jump") > 0 && IsGrounded)
            {
                IsGrounded = false;
                Rb.AddForce(new Vector2(0, jumpForce));
            }
        }

        // private void OnCollisionStay2D(Collision2D other)
        // {
        //     if (!other.gameObject.CompareTag("Ground"))
        //         return;
        //     IsGrounded = true;
        // }
    }
}
