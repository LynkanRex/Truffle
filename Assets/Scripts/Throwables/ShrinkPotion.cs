using UnityEngine;

namespace Throwables
{
    public class ShrinkPotion : MonoBehaviour, IPotion
    {
        [SerializeField] private float shrinkValue;
        public IPotion.PotionType potionType;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (potionType != IPotion.PotionType.Shrink)
                return;
            
            if (other.gameObject.GetComponent<GrowShrinkObject>() != null)
                other.gameObject.GetComponent<GrowShrinkObject>().ModifyValue(-shrinkValue);
            
            Destroy(this.gameObject);
        }
    }
}