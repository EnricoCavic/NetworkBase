using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    [Header("Custom")]
    [SerializeField] private List<string> atributePaths;

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
        var currentAttribute = atributePaths[numPlayers - 1];
        netPlayer.Initialize(currentAttribute);

        Debug.Log("Player joined " + currentAttribute, this);

    }
}
