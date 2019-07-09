using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIImageColorShifter : MonoBehaviour
{
    [SerializeField]
    private Image Renderable;
    [SerializeField]
    private float Timer = 0f;
    private float cTimer = 0f;
    [SerializeField]
    private Vector4 From;
    [SerializeField]
    private Vector4 To = new Vector4(1, 1, 1, 1);

    void Update(){ 
        if(cTimer < Timer) {
            cTimer += Time.deltaTime;
            Vector4 now = Vector4.Lerp(From, To, cTimer / Timer);
            Renderable.color = new Color(now.x, now.y, now.z, now.w);
        } else {
            Renderable.color = new Color(To.x, To.y, To.z, To.w);
        }
    }

    public void SetToColor(Color to){
        cTimer = 0f;
        Timer = 0f;
        Renderable.color = to;
    }

    public void ShiftToColor(Color from, Color to, float timer){
        if(timer <= 0) throw new Exception("Color shifter timer input must be > 0s!");
        Timer = timer;
        ShiftToColor(from, to);
    }

    public void ShiftToColor(Color from, Color to){
        cTimer = 0;
        From = new Vector4(
            from.r,
            from.g,
            from.b,
            from.a
        );
        To = new Vector4(
            to.r,
            to.g,
            to.b,
            to.a
        );
    }
}
