using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkCharacterManager : NetworkBehaviour
{
    [SerializeField] private CharacterAtributes atributes;

    [SyncVar(hook = nameof(SyncAttributePath))]
    [SerializeField] private string attributePath;

    public void SyncAttributePath(string _oldPath, string _newPath)
    {
        Debug.Log($"SyncVar old path : {_oldPath} || new path : {_newPath}", this);
        atributes = Resources.Load<CharacterAtributes>(attributePath);
    }

    [Server]
    public void SetAttributePath(string _newPath)
    {
        Debug.Log($"ServerSet new path : {_newPath}", this);
        attributePath = _newPath;
    }
}
