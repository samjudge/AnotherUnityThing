using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIControlLines : MonoBehaviour
{
    [SerializeField]
    private List<PlayerUIControlLine> List;
    [SerializeField]
    public Transform ItemsParent;

    void Start(){ }

    void Update(){ }

    public int GetSize(){
        return List.Count;
    }

    public PlayerUIControlLine Get(int Index){
        return List[Index];
    }

    public void Add(PlayerUIControlLine Item){
        Item.transform.SetParent(ItemsParent, false);
        List.Add(Item);
    }

    public void Clear(){
        foreach(PlayerUIControlLine Item in List){
            Destroy(Item.gameObject);
        }
        List.Clear();
    }
}
