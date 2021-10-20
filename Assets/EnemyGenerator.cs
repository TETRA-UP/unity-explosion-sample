using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敵のPrefabをInspectorから入れられるように
    public GameObject enemyPrefab;


    //座標の最大値と最小値
    float min = -20f;
    float max = 20f;


    //Generateされた時間
    public float generatedTime = 1f;
    //「Generateされた時間」までカウントするための変数
    private float generateCounter;

    // Update is called once per frame
    void Update()
    {
        if(generateCounter >= generatedTime)
        {
            GenerateEnemy();
            //Counterをリセット
            //これを入れないとUpdate毎にCubeが出てきて大量になるので面白い
            generateCounter = 0;
        }
        //カウンターを＋1秒
        generateCounter += Time.deltaTime;
    }

    //敵を生成
    void GenerateEnemy()
    {
        //updateされる毎に変わる値
        //一度Update（）内に入れてDebugLogで表示させるのも良いかも
        float xRange = Random.Range(min, max);
        float zRange = Random.Range(min, max);
        //敵のPositionを定義。
        Vector3 enemyPosition = new Vector3(xRange, 10f, zRange);

        GameObject enemy = Instantiate(enemyPrefab);
        //PositionをInstanceに代入
        enemy.transform.position = enemyPosition;
    }
}
