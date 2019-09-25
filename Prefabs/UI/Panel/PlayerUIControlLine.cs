using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIControlLine : MonoBehaviour
{
    [SerializeField]
    public Sprite Icon;
    [SerializeField]
    private Image Renderer;
    [SerializeField]
    public Text Text;
    [SerializeField]
    public GameObject Selector;

    void Start(){
        Renderer.sprite = Icon;
    }

    void Update(){
        Renderer.sprite = Icon;
    }
}
