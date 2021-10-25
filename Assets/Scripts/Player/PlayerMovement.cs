using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IPlayerController
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;

        [SerializeField] private AudioClip jumpSFX;
        
        private Rigidbody2D Rb => GetComponent<Rigidbody2D>();
        private Transform transform;
        private AudioSource audioSource;

        public bool IsGrounded { get; set; }
        private void Awake()
        {
            this.transform = GetComponent<Transform>();
            this.audioSource = GetComponent<AudioSource>();
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
                if(audioSource != null && jumpSFX != null)
                    audioSource.PlayOneShot(jumpSFX);
                
                IsGrounded = false;
                Rb.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}
