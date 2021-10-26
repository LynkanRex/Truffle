using UnityEngine;

namespace Throwables
{
    public class GrowShrinkObject : MonoBehaviour
    {
        private float currentVal;

        public void ModifyValue(float val)
        {
            currentVal += val;
            Debug.Log("My value is now " + currentVal);
        }
    }
}