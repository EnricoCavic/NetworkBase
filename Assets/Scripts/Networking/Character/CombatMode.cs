using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cavic.Gameplay;

namespace Cavic.Networking.Character
{
    public class CombatMode : NetworkBehaviour
    {
        private CharacterUI characterUI;
        private bool inCombat = false;

        public void CacheComponents()
        {
            if (characterUI != null) return;
            characterUI = GetComponent<CharacterUI>();
        }

        // commands e rpcs rodam APENAS neste objeto, a diferença é onde eles rodam
        // mais ou menos um sync function onde cmd valida no server e rcp distribui pela rede

        // cmds sincronizam a informação local para o servidor
        [Command]
        public void CmdCombatMode(CharacterAtributes _atributes)
        {
            Debug.Log($"Cmd {_atributes.name} requested combat mode", this);
            if(!inCombat)
            {
                RcpEnterCombatMode(_atributes);
                inCombat = true;
            }
            else
            {
                RcpExitCombatMode(_atributes);
                inCombat = false;
            }
        }

        // rpcs reproduzem as informações retidas no server pelo cmd
        // elas são direcionadas para o objeto que contém essa função em todos os clientes
        [ClientRpc]
        private void RcpEnterCombatMode(CharacterAtributes _atributes)
        {
            Debug.Log($"Rcp {_atributes.name} entered combat mode", this);
            CacheComponents();
            characterUI.CombatDisplay(_atributes);
        }

        [ClientRpc]
        private void RcpExitCombatMode(CharacterAtributes _atributes)
        {
            Debug.Log($"Rcp {_atributes.name} exit combat mode", this);
            CacheComponents();
            characterUI.NameDisplay(_atributes);
        }
    }
}