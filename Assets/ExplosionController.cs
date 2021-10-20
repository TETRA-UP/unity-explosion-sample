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

        // 設定した座標＝Positionから見た範囲＝Radius内の個数を取得
        // RigidbodyにAddExplosionForce
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb == true)
            {
                //力、座標、半径、上への向き
                rb.AddExplosionForce(force, position, radius, upwards, ForceMode.Impulse);
                
            }
        }
    }
}