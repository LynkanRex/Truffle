using UnityEngine;

namespace Throwables
{
    public class ShrinkPotion : MonoBehaviour, IPotion
    {
        [SerializeField] private float shrinkValue;
        [SerializeField] private float radius;
        public IPotion.PotionType potionType;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (potionType != IPotion.PotionType.Shrink)
                return;
            
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
            foreach (var collider in hitColliders)
            {
                if (collider.GetComponent<GrowShrinkObject>() != null)
                    collider.GetComponent<GrowShrinkObject>().ModifyValue(-shrinkValue);
            }
        }
    }
}