using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class NetworkWorldSpaceUI : MonoBehaviour
{
    public NetworkIdentity identity;

    private Transform worldSpaceCanvas;
    private TextMeshProUGUI uiElement;

    public void Initialize()
    {
        if (uiElement != null) return;
        uiElement = GetComponent<TextMeshProUGUI>();

        worldSpaceCanvas = GameObject.FindGameObjectWithTag("WorldSpaceCanvas").transform;
        transform.SetParent(worldSpaceCanvas);
    }

    public void SetElementText(string _newText) => uiElement.text = _newText;
}
