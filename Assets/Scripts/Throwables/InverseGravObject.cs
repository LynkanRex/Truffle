using System;
using System.Collections;
using UnityEngine;

namespace Throwables
{
    public class InverseGravObject : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private float antiGravForce;

        [SerializeField] private Rigidbody2D rb2d;
        
        private void Start()
        {
            StartCoroutine(TickAndDie());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            rb2d = other.gameObject.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (rb2d == null)
                return;
            
            rb2d.AddForce(new Vector2(0, antiGravForce));
        }

        private void OnTriggerStay(Collider other)
        {
            if (rb2d == null)
                return;
            
            rb2d.AddForce(new Vector2(0, 1 + (antiGravForce * Time.fixedDeltaTime)));
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            rb2d = null;
        }
        
        private IEnumerator TickAndDie()
        {
            while (lifeTime != 0)
            {
                yield return new WaitForSeconds(1.0f);
                lifeTime--;
            }
            
            Destroy(this.gameObject);
        }
    }
}