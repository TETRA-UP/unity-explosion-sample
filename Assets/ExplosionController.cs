using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] float force = 20;
    [SerializeField] float radius = 5;
    [SerializeField] float upwards = 0;
    Vector3 position;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        particle.gameObject.SetActive(true);
        particle.Play();
        position = particle.transform.position;

        // 範囲内のRigidbodyにAddExplosionForce
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(force, position, radius, upwards, ForceMode.Impulse);
            }
        }
    }
}