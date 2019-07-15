using UnityEngine;

public class MagicMissileBehaviour : MonoBehaviour
{
    public Vector3 Direction { get; internal set; }

    private float Lifetime = 3f;
    private float cLifetime = 0f;

    void Update(){
        transform.position = transform.position + (Time.deltaTime * 2f) * Direction.normalized;
        cLifetime += Time.deltaTime;
        if(cLifetime > Lifetime){
            Destroy(gameObject);
        }
    }
}