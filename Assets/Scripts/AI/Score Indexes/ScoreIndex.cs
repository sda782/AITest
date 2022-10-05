using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Score Index")]
public class ScoreIndex : ScriptableObject {

    public List<Score> scores;

    [System.Serializable]
    public struct Score {
    public AIActions actionType;
    public AnimationCurve scoreCurve;
        
    }
}