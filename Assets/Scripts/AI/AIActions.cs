using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIActions {
    BLOCK_OPPONENT, 
    PLACE_AT_LOWEST_INDEX,
    PLACE_AT_RANDOM_INDEX,
    PLACE_FOR_WIN,
    PLACE_NEAR_ALLY_PIECES,
    PLACE_NEAR_ENEMY_PIECES,
    TEST_BUCKET
}