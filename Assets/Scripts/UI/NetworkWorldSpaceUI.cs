using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class NetworkWorldSpaceUI : MonoBehaviour
{
    private Transform worldSpaceCanvas;
    private TextMeshProUGUI uiElement;

    public void Initialize()
    {
        if (uiElement != null) return;
        uiElement = GetComponentInChildren<TextMeshProUGUI>();

        worldSpaceCanvas = GameObject.FindGameObjectWithTag("WorldSpaceCanvas").transform;
        transform.SetParent(worldSpaceCanvas);
        transform.LookAt(Camera.main.transform.position);
    }

    public void SetElementText(string _newText) => uiElement.text = _newText;
}
