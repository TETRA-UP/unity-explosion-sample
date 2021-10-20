using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Inspectorから見やすくするためPublic
    public float z;


    public GameObject point;
    public GameObject bulletPrefab;
    public float shotPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //zの値を更新して動きをつける
        if (Input.GetKey(KeyCode.UpArrow))
        {
            z = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            z = -1;
        }
        //Keyが押されなくなったら0にして止める
        if(Input.GetKeyUp(KeyCode.UpArrow) | Input.GetKeyUp(KeyCode.DownArrow))
        {
            z = 0;
        }

        //Positionを変更
        gameObject.transform.position += gameObject.transform.rotation * new Vector3(0, 0, z);
        //こっちの方が見やすい
        //Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, z);
        //gameObject.transform.position += velocity * Time.deltaTime;

        //向きを変える
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -3f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 3f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    // 弾を撃つ
    void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = point.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shotPower);
    }
}
