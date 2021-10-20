using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator instance;
    private void Awake()
    {
        instance = this;
    }


    //GameObject directorPrefab;

    //GameDirector gameDirector;

    public GameObject enemyPrefab;

    public GameObject target;


    float min = -20f;
    float max = 20f;



    public float generatedTime = 1f;
    private float generateCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(generateCounter >= generatedTime)
        {
            float xRange = Random.Range(min, max);
            float zRange = Random.Range(min, max);
            //敵のPositionを定義。ランダム
            Vector3 position = new Vector3(xRange, 10f, zRange);
            //position += target.transform.position;

            Generate(position);
            //これを入れないとUpdate毎にCubeが出てきて面白い
            generateCounter = 0;
        }
        //カウンターを＋1秒
        generateCounter += Time.deltaTime;
    }

    //敵を生成
    void Generate(Vector3 position)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = position;
        //GameObject enemy = Instantiate(enemyPrefab).gameObject.GetComponent<>();
        //enemy.target = targetPrefab;


    }
}
