using UnityEngine;

namespace Throwables
{
    public class InverseGravPotion : MonoBehaviour, IPotion
    {
        [SerializeField] private GameObject antiGravityAreaObject;
        
        public IPotion.PotionType potionType;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (potionType != IPotion.PotionType.InverseGravity)
                return;
            
            if (antiGravityAreaObject == null)
                return;
            
            Instantiate(antiGravityAreaObject, this.transform.position, this.transform.rotation);
            
            Destroy(this.gameObject);
        }
    }
}