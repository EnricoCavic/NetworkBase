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
        [SerializeField] private CharacterUI characterUI;
        [SerializeField] private NetworkBattler battler;
        [SerializeField] private CharacterMovement characterMovement;

        [SerializeField] Transform testPosition;

        [SyncVar(hook = nameof(SyncScharAtributes))]
        [SerializeField] private CharacterAtributes charAtributes;
        public void SyncScharAtributes(CharacterAtributes _oldAtributes, CharacterAtributes _newAtributes)
        {
            if (_oldAtributes == _newAtributes) return;
            characterUI.NameDisplay(charAtributes);
            battler.Initialize(charAtributes);
        }
        
        [Server]
        public void Initialize(CharacterAtributes _atributes)
        {
            charAtributes = _atributes;
            characterUI.CacheComponents();
        }

        public void SetBattlerTartget(NetworkCharacterManager _characterManager)
        {
            battler.SetTarget(_characterManager.GetComponent<NetworkBattler>());
        }

        public void MoveTo(Transform transform)
        {
            characterMovement.SetDestination(transform.position);
        }


        public override void OnStopClient()
        {
            base.OnStopClient();
            characterUI.DestroyDisplay();
        }

    }
}