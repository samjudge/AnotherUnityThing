using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ColorShifter : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer Renderable;
    [SerializeField]
    private float Timer = 0f;
    private float cTimer = 0f;
    [SerializeField]
    private Vector3 From;
    [SerializeField]
    private Vector3 To = new Vector3(1, 1, 1);

    void Update(){ 
        if(cTimer < Timer) {
            cTimer += Time.deltaTime;
            Vector3 now = Vector3.Lerp(From, To, cTimer / Timer);
            Renderable.color = new Color(now.x, now.y, now.z);
        } else {
            Renderable.color = new Color(To.x, To.y, To.z);
        }
    }

    public void SetToColor(Color to){
        cTimer = 0f;
        Timer = 0f;
        Renderable.color = to;
    }

    public void ShiftToColor(Color from, Color to, float timer){
        if(timer <= 0) throw new Exception("Color shifter timer input must be > 0s!");
        cTimer = 0;
        Timer = timer;
        this.From = new Vector3(
            from.r,
            from.g,
            from.b
        );
        this.To = new Vector3(
            to.r,
            to.g,
            to.b
        );
    }
}
