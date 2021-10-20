using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public static ExplosionController instance;
    public ParticleSystem particle;
    public float force = 20;
    public float radius = 5;
    public float upwards = 0;
    Vector3 position;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        particle.gameObject.SetActive(false);
    }
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
            Debug.Log(hitColliders);
            Debug.Log(hitColliders[i]);
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb == true)
            {
                //力、座標、半径、上への向き
                rb.AddExplosionForce(force, position, radius, upwards, ForceMode.Impulse);
                
            }
        }
    }
}