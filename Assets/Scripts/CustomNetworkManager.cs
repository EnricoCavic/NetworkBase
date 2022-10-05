using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("Init generalizada em players locais");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log("Reação do server a entrada de players");
        Debug.Log("Player joined" + conn.identity.netId);
        Debug.Log("Total players" + numPlayers);

    }
}
