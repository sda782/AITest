using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBucket : BaseAction{
    
    protected List<IAction> _actions;
    protected void DecideActionAndRun(List<IAction> actions) {
        float currentHighScore = 0;
        IAction actionToRun = null;

        foreach (var action in actions) {
            float currentActionScore = action.Score();
            if (currentHighScore >= currentActionScore) continue;

            currentHighScore = currentActionScore;
            actionToRun = action;
        }
        Debug.Log("bucket high score " + currentHighScore);
        actionToRun?.Act();
    }
}
