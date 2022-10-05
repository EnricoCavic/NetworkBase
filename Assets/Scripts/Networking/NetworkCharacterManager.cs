using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkCharacterManager : NetworkBehaviour
{
    [SerializeField] private CharacterAtributes atributes;

    [SyncVar]
    [SerializeField] private string atributePath;

    public void SyncDisplayName(string oldPath, string newPath)
    {
        if (newPath.Equals(oldPath)) return;
        atributes = Resources.Load<CharacterAtributes>(atributePath);
    }

    public void SetupCharacter(string _newName)
    {
        atributePath = _newName;
        atributes = Resources.Load<CharacterAtributes>(atributePath);
    }
}
