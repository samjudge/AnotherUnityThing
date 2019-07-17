using UnityEngine;

public class MagicMissileBehaviour : MonoBehaviour
{
    public Transform EndTargetBody;
    [SerializeField]
    private float Lifetime = 3f;
    private float cLifetime = 0f;
    [SerializeField]
    private float Speed = 1f;
    [SerializeField]
    private float MinArcForce = 0.75f;
    [SerializeField]
    private float MaxArcForce = 1.25f;
    private Vector3 StartPos;
    private Vector3 ArcPeakPos;

    void Start(){
        //calculate direction
        Vector3 direction = (EndTargetBody.position - transform.position).normalized;
        //where the pathVector
        //is the total vector travelled as a straight line
        Vector3 pathVector = Speed * Lifetime * direction.normalized;
        //randomize arcPeak
        StartPos = this.transform.position;
        //where the arc peak is half way through the pathVector, with a raised peak
        ArcPeakPos = StartPos +
            pathVector / 2 +
            Quaternion.AngleAxis(
                Dice.Roll(0f,180f) - 90f,
                direction.normalized
            ) * new Vector3(0f, Dice.Roll(MinArcForce, MaxArcForce), 0f);
    }

    void Update(){
        //update the position
        transform.position = BezUtils.Bez3(
            StartPos,
            ArcPeakPos,
            EndTargetBody.transform.position,
            cLifetime/Lifetime
        );
        //update the time delta
        cLifetime += Time.deltaTime;
        if(cLifetime > Lifetime){
            Destroy(gameObject);
        }
    }
}