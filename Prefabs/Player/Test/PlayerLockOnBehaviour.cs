using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLockOnBehaviour : MonoBehaviour, LockOnable {

    [SerializeField]
    private Image Reticule;
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Camera Face;
    [SerializeField]
    private float MaxLockOnDistance;
    [SerializeField]
    private OnLockEventEmitter PlayerLockOnEmitter;
    
    public bool IsLockedOn { get; private set; }
    public Transform LockedOnTransform  { get; private set; }

    void Awake() {
        if(Face == null) {
            Debug.LogWarning("No Face set for PlayerLockedOnBehaviour, using Camera.main");
            Face = Camera.main;
        }
    }

    void Update(){
        if(IsLockedOn) {
            MoveReticuleToWorldPosition(LockedOnTransform.position);
        }
    }

	public void MoveReticuleToWorldPosition(Vector3 To){
        Reticule.rectTransform.position = Face.WorldToScreenPoint(To);
    }

    public void LockOntoHoveredNearEnemy(OnMouseMoveEventData e){
        //add throttle maybe?
        //raycast with mouse
        Ray mouseRay = Face.ScreenPointToRay(e.NewMousePosition);
        RaycastHit[] mouseRayHits = Physics.RaycastAll(mouseRay, MaxLockOnDistance);
        foreach(RaycastHit mh in mouseRayHits){
            if(mh.collider.GetComponent<OnLockEventEmitter>()){
                GameObject hitWith = mh.collider.gameObject;
                Ray playerRay = new Ray(
                    Player.position,
                    (Player.position -
                        hitWith.transform.position
                    ).normalized
                );
                RaycastHit[] playerRayHits = Physics.RaycastAll(
                    mouseRay,
                    MaxLockOnDistance
                );
                foreach(RaycastHit ph in mouseRayHits){
                    if(ph.collider.GetComponent<OnLockEventEmitter>()){
                        float distance = (
                            ph.transform.position -
                            Player.transform.position
                        ).magnitude;
                        if(distance < MaxLockOnDistance){
                            MakeLock(ph.collider.gameObject);
                        }
                        OnLockEventEmitter Emitter =
                            ph.collider.GetComponent<OnLockEventEmitter>();
                        Emitter.LockOnSource = this;
                        Emitter.Emit(new OnLockAttainEventData(this));
                    }
                }
            }
        }
    }

    public void MakeLock(GameObject On)
    {
        LockedOnTransform = On.transform;
        IsLockedOn = true;
        MoveReticuleToWorldPosition(LockedOnTransform.position);
    }

    public void RemoveLock()
    {
        this.LockedOnTransform = null;
        this.IsLockedOn = false;
    }
}
