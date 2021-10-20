using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Inspectorから見やすくするためPublic
    //動き
    public float z;

    //Canonの先っぽのところの座標を取得するため
    public GameObject shotPoint;
    //弾のPrefab
    public GameObject bulletPrefab;
    //弾の発射威力
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

        //Positionを変更
        //こっちの方が見やすいかも？
        //Vector3 rotation = gameObject.transform.rotation * new Vector3(0, 0, z);
        //gameObject.transform.position += rotation * Time.deltaTime;

        //向きを変える
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -3f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 3f, 0f);
        }

        //発射
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    // 弾を撃つ
    void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        //Canonの先っぽのところを初期位置にする
        bullet.transform.position = shotPoint.transform.position;
        //発射
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shotPower);
    }
}
