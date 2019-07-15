using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLockOnBehaviour : MonoBehaviour {

    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Camera Face;
    [SerializeField]
    private float MaxLockOnDistance;
    private OnLockEventEmitter LastLockedOn;
    public Transform LockedOntoBody { get; private set; }
    
    void Awake(){
        if(Face == null){
            Face = Camera.main;
        }
    }

    void Update(){ }

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
                            OnLockEventEmitter Emitter =
                                    ph.collider.GetComponent<OnLockEventEmitter>();
                            if(LastLockedOn != Emitter) {
                                Emitter.Emit(new OnLockAttainEventData());
                                if(LastLockedOn != null){
                                    LastLockedOn.Emit(new OnLockReleaseEventData());
                                }
                                LastLockedOn = Emitter;
                                LockedOntoBody = Emitter.transform;
                            }
                        }
                    }
                }
            }
        }
    }
}
