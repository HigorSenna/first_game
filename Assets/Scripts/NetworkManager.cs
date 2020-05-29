using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using Assets.DTO.Response;

public class NetworkManager : MonoBehaviour

{
    public static NetworkManager networkManager;
    public SocketIOComponent socketIo;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        if (networkManager == null)
        {
            networkManager = this;

            socketIo = GetComponent<SocketIOComponent>();

            socketIo.On("pong", this.OnReceivedPong);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    void OnReceivedPong(SocketIOEvent socketIOEvent)
    {
        Dictionary<string, string> result = socketIOEvent.data.ToDictionary();

        //Debug.Log(socketIOEvent.data.);
        
        Debug.Log("mensagem do servidor: " + result["message"]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendPingToServer()
    {
        UserResponseDTO userDTO = new UserResponseDTO();
        userDTO.id = 1;
        userDTO.name = "Player 1";        
        userDTO.email = "player1@gmail.com";
        Dictionary<string, string> pack = new Dictionary<string, string>();
        pack["message"] = "message ping!!";
        
        Debug.Log(JsonUtility.ToJson(userDTO));
        socketIo.Emit("ping", new JSONObject(JsonUtility.ToJson(userDTO)));
       
    }
}
