using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cavic.Networking.Character;

public class NetworkCharacterManager : NetworkBehaviour
{
    [SerializeField] private CharacterAtributes atributes;

    [SerializeField] private CharacterUI characterUI;

    [SyncVar(hook = nameof(SyncAttributePath))]
    [SerializeField] private string attributePath;
    public void SyncAttributePath(string _oldPath, string _newPath)
    {
        Debug.Log($"SyncVar old path : {_oldPath} || new path : {_newPath}", this);
        atributes = Resources.Load<CharacterAtributes>(attributePath);
        StartCoroutine(WaitForAttributes());
    }

    public IEnumerator WaitForAttributes()
    {
        yield return new WaitUntil(() => atributes != null);
        characterUI.NameDisplay(atributes);
    }

    [Server]
    public void Initialize(string _newPath)
    {
        Debug.Log($"ServerInitialize new path : {_newPath}", this);
        attributePath = _newPath;
        characterUI.CacheComponents();
    }
}
