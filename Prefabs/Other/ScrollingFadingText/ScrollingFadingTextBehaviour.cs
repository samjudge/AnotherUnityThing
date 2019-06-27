using UnityEngine;
using UnityEngine.UI;

public class ScrollingFadingTextBehaviour : MonoBehaviour
{
    [SerializeField]
    public Text Message;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Lifespan;
    private float cLifespan;
    private Vector2 InitalPosition;
    private Vector2 TargetPosition;
    [SerializeField]
    private Vector2 Direction;
    
    void Start() {
        InitalPosition = Message.rectTransform.localPosition;
        TargetPosition = InitalPosition + ((Direction.normalized * Speed) * Lifespan);
    }

    void Update() {
        Message.rectTransform.localPosition = Vector2.Lerp(InitalPosition, TargetPosition, cLifespan / Lifespan);
        if(cLifespan > Lifespan) Destroy(this.gameObject);
        Message.color = new Color(
            Message.color.r,
            Message.color.g,
            Message.color.b,
            1 - (cLifespan / Lifespan)
        );
        cLifespan += Time.deltaTime;
    }
}