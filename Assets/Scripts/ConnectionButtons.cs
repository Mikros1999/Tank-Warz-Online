using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ConnectionButtons : MonoBehaviour
{
    // Host Server
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    // Join Server
    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
