using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;

public class NetworkButtons : MonoBehaviour
{
    private UIDocument document;
    private Button host, server, client;

    // Start is called before the first frame update
    void Start()
    {
        document = FindObjectOfType<UIDocument>();
        host = document.rootVisualElement.Q<Button>("host");
        server = document.rootVisualElement.Q<Button>("server");
        client = document.rootVisualElement.Q<Button>("client");
        
        host.RegisterCallback<ClickEvent>(evt => NetworkManager.Singleton.StartHost());
        server.RegisterCallback<ClickEvent>(evt => NetworkManager.Singleton.StartServer());
        client.RegisterCallback<ClickEvent>(evt => NetworkManager.Singleton.StartClient());
    }
}
