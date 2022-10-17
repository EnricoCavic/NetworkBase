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

        private void PlayerSetup(NetworkConnectionToClient conn)
        {
            var netPlayer = conn.identity.GetComponent<NetworkCharacterManager>();
            var playerAttribute = atributes[numPlayers - 1];

            players.Add(netPlayer);
            netPlayer.Initialize(playerAttribute);

            if(players.Count == 2)
            {
                players[0].SetBattlerTartget(players[1]);
                players[1].SetBattlerTartget(players[0]);
            }

            Debug.Log("Player joined " + playerAttribute.displayName , netPlayer);

        }

    }
}
