using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.FPS.Game;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] float Damage = 1f;
    [SerializeField] float time = 1f;

    private void OnTriggerStay(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable) {
            StartCoroutine(TakeDamage(time, damageable));
        }   
    }

    IEnumerator TakeDamage(float time, Damageable damageable) 
    {
        damageable.InflictDamage(Damage, false, gameObject);
        //GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(time);
        //GetComponent<BoxCollider>().isTrigger = true;    
    }
}
