using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cavic.Gameplay;
using Mirror;
using System;

namespace Cavic.Networking.Character
{
    public class NetworkBattler : NetworkBehaviour
    {
        [SerializeField] private AnimationManager animationManager;

        [Header("Atributes")]
        [SerializeField] private Atributes originalAtributes;

        [SyncVar]
        [SerializeField] private int currentHp;

        [SyncVar]
        [SerializeField] private int currentDamage;

        [SyncVar]
        [SerializeField] private int currentSpeed = 1;

        private NetworkBattler target;
        public event Action ServerOnDied;

        public override void OnStartServer()
        {
            base.OnStartServer();
            animationManager.onHitFrame += OnHitFrame;
            animationManager.onAttackFinished += OnAttackFinished;
        }

        public void Initialize(CharacterAtributes _charAtributes)
        {
            originalAtributes = new();
            originalAtributes.hp = _charAtributes.atributes.hp;
            originalAtributes.damage = _charAtributes.atributes.damage;
            originalAtributes.speed = _charAtributes.atributes.speed;

            currentHp = originalAtributes.hp;
            currentDamage = originalAtributes.damage;
            currentSpeed = originalAtributes.speed;

        }

        [ServerCallback]
        private void Update()
        {
            if (target == null) return;
            if (CanAttack())
            {
                animationManager.StartAttack(1, currentSpeed);
            }
            else animationManager.StopAttack(1);
        }

        float lastAttackFrame;
        [Server]
        private bool CanAttack()
        {
            if (target == null || animationManager.IsAttacking) return false;
            float attackInterval = 10 / currentSpeed;
            return Time.time > attackInterval + lastAttackFrame;
        }

        [Server]
        public void SetTarget(NetworkBattler _newTarget) => target = _newTarget;

        [Server]
        private void OnAttackFinished()
        {
            lastAttackFrame = Time.time;
        }

        [Server] 
        public void OnHitFrame()
        {
            target.SetHP(-currentDamage);
        }

        [Server]
        public void SetHP(int _value)
        {
            if (currentHp <= 0) return;
            currentHp = Mathf.Clamp(currentHp + _value, 0, originalAtributes.hp);
            Debug.Log("ServerSetHP personagem recebeu dano");

            if (currentHp > 0) return;
            ServerOnDied?.Invoke();
            Debug.Log("ServerSetHP personagem morreu");
            Destroy(gameObject);
        }
        
    }
}