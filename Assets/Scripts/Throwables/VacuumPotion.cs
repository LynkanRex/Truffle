using UnityEngine;

namespace Throwables
{
    public class VacuumPotion : MonoBehaviour, IPotion
    {
        [SerializeField] private float radius;
        [SerializeField] private float suctionPower;
        
        
        public IPotion.PotionType potionType;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (potionType != IPotion.PotionType.Vacuum)
                return;

            Vector2 dir = this.transform.position;
            
            dir.x *= suctionPower;
            dir.y *= suctionPower;
            
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
            foreach (var collider in hitColliders)
            {
                if (collider.GetComponent<Rigidbody2D>() != null)
                    collider.GetComponent<Rigidbody2D>().AddForce(dir);
            }
            
            Destroy(this.gameObject);
        }
    }
}
