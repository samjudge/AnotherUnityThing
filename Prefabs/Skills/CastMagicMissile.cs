using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CastMagicMissile : MonoBehaviour
{
    public GameObject Owner;
    [SerializeField]
    public MagicMissileBehaviourFactory MissileFactory;

    public void Cast(GameObject At){
        MissileFactory.Make(At.transform);
    }
}