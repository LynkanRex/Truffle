using UnityEngine;

namespace Player
{
    public class GroundCheck : MonoBehaviour
    {
    
        private PlayerMovement playerController;
    
        // Start is called before the first frame update
        void Start()
        {
            playerController = GetComponentInParent<PlayerMovement>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ground"))
                return;

            playerController.IsGrounded = true;
        }
    }
}
