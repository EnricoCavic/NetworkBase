using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cavic.Gameplay;

namespace Cavic.Networking
{

    public class CustomNetworkManager : NetworkManager
    {
        [Header("Custom")]
        [SerializeField] private List<CharacterAtributes> atributes;

        [SerializeField] private List<NetworkCharacterManager> players;

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            Debug.Log("Init generalizada em players locais", this);
        }

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn);
            Debug.Log("Reação do server a entrada de players", this);
            PlayerSetup(conn);
            Debug.Log("Total players" + numPlayers, this);
        }

        [Server]
        private void PlayerSetup(NetworkConnectionToClient conn)
        {
            var characterManager = conn.identity.GetComponent<NetworkCharacterManager>();
            var playerAttribute = atributes[numPlayers - 1];

            players.Add(characterManager);
            characterManager.Initialize(playerAttribute);

            bool isRoomFull = players.Count == 2;
            if (isRoomFull)
            {
                players[0].SetBattlerTartget(players[1]);
                players[1].SetBattlerTartget(players[0]);
            }

            Debug.Log("Player joined " + playerAttribute.displayName , characterManager);

        }

    }
}
