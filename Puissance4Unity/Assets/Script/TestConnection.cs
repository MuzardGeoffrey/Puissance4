using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnection : MonoBehaviour
{
    // Start is called before the first frame update
    public async void Connection()
    {
        PlayerConnection playerConnection = new PlayerConnection();

        await playerConnection.Connection(new Player { Pseudo = "ef", Password = "on peut" });
    }
}
