using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinateSlimeForestMap : MonoBehaviour {
    
    [SerializeField]
    private Vector2 Size;
    [SerializeField, Range(0f,1f)]
    private float SlimeDensity = 0.05f;
    [SerializeField, Range(0f,1f)]
    private float TreeDensity = 0.1f;
    
    [SerializeField]
    private GameObject SlimePrefab;
    [SerializeField]
    private GameObject TreePrefabA;
    [SerializeField]
    private GameObject TreePrefabB;
    [SerializeField]
    private GameObject GroundPrefab;
    [SerializeField]
    private GameObject AreaExitPrefab;

    private System.Random Dice;

    public void Awake(){
        Dice = new System.Random();
    }

    public void Start(){
        SpawnLevel();
    }

    private void SpawnLevel(){
        for(int x = 0; x <= Size.y; x++) {
            for(int y = 0; y <= Size.y; y++) {
                SpawnBlock(x, y);
                if(y == Size.y || y == 0 || x == Size.x || x == 0) {
                    SpawnExitZone(x, y);
                }
            }
        }
    }

    public void SpawnExitZone(float x, float y){
        GameObject exitZone = Instantiate(AreaExitPrefab);
        exitZone.transform.SetParent(this.transform);
        exitZone.transform.localPosition = new Vector3(x, 0f, y);
    }

    public void SpawnBlock(float x, float y){
        if( //roll for spwan slime
            IsRollLessThan(this.SlimeDensity)
        ){
            GameObject prefab = Instantiate(SlimePrefab);
            prefab.transform.SetParent(this.transform);
            prefab.transform.localPosition = new Vector3(x, 0.3f, y);
        } else if( //roll for spwan tree
            IsRollLessThan(this.TreeDensity)
        ){
            GameObject prefab = null;
            if(IsRollLessThan(0.5f)){
                prefab = Instantiate(TreePrefabA);
            } else {
                prefab = Instantiate(TreePrefabB);
            }
            prefab.transform.SetParent(this.transform);
            prefab.transform.localPosition = new Vector3(x, 0.3f, y);
        }
        //spwan ground tile
        GameObject ground = Instantiate(GroundPrefab);
        ground.transform.SetParent(this.transform);
        ground.transform.localPosition = new Vector3(x, 0f, y);
    }

    private bool IsRollLessThan(float Odds){
        float roll = (Dice.Next() % 100f) / 100f;
        if(roll >= Odds){
            return false;
        }
        return true;
    }
}
