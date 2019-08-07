using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSpearmanCorpseBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ResurrectAs;

    public void OnResurrect(OnResurrectEventData e){
        //create a zombie goblin spearman and destroy the corpse
        GameObject g = Instantiate(ResurrectAs);
        g.transform.position = transform.position;
        Destroy(gameObject);
    }
}
