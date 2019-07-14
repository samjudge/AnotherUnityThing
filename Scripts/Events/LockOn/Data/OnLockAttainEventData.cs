using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OnLockAttainEventData
{
    public LockOnable LockBehaviour;

    public OnLockAttainEventData(LockOnable LockBehaviour){
        this.LockBehaviour = LockBehaviour;
    }
}
