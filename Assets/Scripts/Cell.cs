using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler {
    public int x, y;
    public Action<Cell> cellClicked;

    public void OnPointerClick(PointerEventData eventData) {
        cellClicked?.Invoke(this);
    }
}
