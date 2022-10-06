using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBucket : BaseBucket, IAction {
    
    public TestBucket(GameRenderer gameRenderer) {
        SetUpVariables(gameRenderer,AIActions.TEST_BUCKET);
        
        _actions = new List<IAction> {
            new PlaceAtRandomIndex(_gameRenderer)
        };
    }

    public void Act() {
        Debug.Log("TestBucket");
        DecideActionAndRun(_actions);   
    }

    public float Score() {
        return _scoreCurve.Evaluate(0.5f);
    }
    
}
