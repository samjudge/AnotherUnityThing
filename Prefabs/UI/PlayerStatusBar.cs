using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBar : MonoBehaviour
{
    [SerializeField]
    private StatusCollection StatusCollection;
    [SerializeField]
    private List<Image> StatusImages;
    [SerializeField]
    private Image StatusImagePrefab;

    void Start(){ }

    void Update(){
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
        for(int n = 0; n < StatusCollection.GetStatuses().Count ; n++){
            Status s = StatusCollection.GetStatuses()[n];
            Image i = Instantiate(StatusImagePrefab);
            i.sprite = StatusCollection.GetStatuses()[n].UIStatusImage;
            i.transform.SetParent(transform, false);
        }
    }

}
