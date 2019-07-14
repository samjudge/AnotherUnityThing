using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OnLockReleaseEventData
{
    public LockOnable LockBehaviour;

    public OnLockReleaseEventData(LockOnable LockBehaviour){
        this.LockBehaviour = LockBehaviour;
    }
}