using UnityEngine;

namespace Throwables
{
    public class GrowPotion : MonoBehaviour, IPotion
    {
        [SerializeField] private float growValue;
        public IPotion.PotionType potionType;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (potionType != IPotion.PotionType.Grow)
                return;
            
            if (other.gameObject.GetComponent<GrowShrinkObject>() != null)
                other.gameObject.GetComponent<GrowShrinkObject>().ModifyValue(growValue);
            
            Destroy(this.gameObject);
        }
    }
}