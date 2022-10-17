using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cavic.Networking.Character;
using Cavic.Gameplay;
using System;

namespace Cavic.Networking
{
    public class NetworkCharacterManager : NetworkBehaviour
    {
        [SyncVar(hook = nameof(SyncScharAtributes))]
        [SerializeField] private CharacterAtributes charAtributes;
        public void SyncScharAtributes(CharacterAtributes _oldAtributes, CharacterAtributes _newAtributes)
        {
            if (_oldAtributes == _newAtributes) return;
            characterUI.NameDisplay(charAtributes);
            battler.Initialize(charAtributes);
        }

        [SerializeField] private CharacterUI characterUI;
        [SerializeField] private NetworkBattler battler;
        
        [Server]
        public void Initialize(CharacterAtributes _atributes)
        {
            charAtributes = _atributes;
            characterUI.CacheComponents();
        }

        [Server]
        public void SetBattlerTartget(NetworkCharacterManager _characterManager)
        {
            battler.SetTarget(_characterManager.GetComponent<NetworkBattler>());
        }


        public override void OnStopClient()
        {
            base.OnStopClient();
            characterUI.DestroyDisplay();
        }

    }
}