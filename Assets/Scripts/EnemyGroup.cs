using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemiesParent;
    
    [SerializeField] private int amount;
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    void Start(){
        GenerateEnemies();
    }

    private void GenerateEnemies(){
        for(int i=0; i<amount; i++){
            Vector3 enemyLocalPosition = GetRunnerLocalPosition(i);

            Vector3 enemyWorldPosition = enemiesParent.TransformPoint(enemyLocalPosition);

            Instantiate(enemyPrefab,enemyWorldPosition,Quaternion.identity, enemiesParent);
        }
    }

    private Vector3 GetRunnerLocalPosition(int index){
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index *angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index *angle);
    
        return new Vector3(x,0,z);    
    }
}
