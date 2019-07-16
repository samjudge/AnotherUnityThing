using UnityEngine;

public class MagicMissileBehaviour : MonoBehaviour
{
    public Vector3 Direction;
    [SerializeField]
    private float Lifetime = 3f;
    private float cLifetime = 0f;
    [SerializeField]
    private float Speed = 1f;
    [SerializeField]
    private float MaxArcForce = 3f;


    private Vector3 startPos;
    private Vector3 arcPeak;
    private Vector3 endPos;

    void Start(){
        //some values...
        Vector3 pathVector = Speed * Lifetime * Direction.normalized;
        //randomize arcPeak
        startPos = this.transform.position;
        arcPeak = startPos +
            pathVector / 2 +
            Quaternion.AngleAxis(
                Dice.Roll(0f,180f) - 90f,
                Direction.normalized
            ) * new Vector3(0f, 1f, 0f);
        endPos = startPos + pathVector;
    }

    void Update(){
        transform.position = BezUtils.Bez3(
            startPos,
            arcPeak,
            endPos,
            cLifetime/Lifetime
        );
        cLifetime += Time.deltaTime;
        if(cLifetime > Lifetime){
            Destroy(gameObject);
        }
    }
}