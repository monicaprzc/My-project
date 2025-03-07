using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platypus : Animal, IOviparo, ISubsystem
{
    public bool running => throw new System.NotImplementedException();

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public void LayEggs(int _days)
    {
        throw new System.NotImplementedException();
    }

    public void Start()
    {
        throw new System.NotImplementedException();
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }

    public void WhenTheEggsHatched()
    {
        throw new System.NotImplementedException();
    }

    bool IOviparo.HaveEggsHatched()
    {
        return false;
    }
}
