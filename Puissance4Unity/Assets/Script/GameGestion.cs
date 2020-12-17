using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGestion : MonoBehaviour
{
    public Player PlayerOne;
    public Player PlayerTwo;
    public int PlayerTurn;

    private int[,] gameSpace = new int[7,6];
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                gameSpace[i, j] = 0;
                PlayerTurn = 1;
            }
        } 
    }

    public void Playjeton(int culumn)
    {
        int row = 0;
        while (gameSpace[culumn,row] == 0 && row > 6)
        {
            Debug.Log("while");
            if (gameSpace[culumn, row] != 0)
            {
                Debug.Log("if");
                gameSpace[culumn, row] = PlayerTurn;

                switch (PlayerTurn)
                {
                    case 1 :
                        PlayerTurn = 2;
                        Debug.Log("1");
                        break;
                    case 2:
                        PlayerTurn = 1;
                        Debug.Log("2");
                        break;

                    default:
                        Debug.LogError("Error player turn");
                        break;
                }
            }
            row++;
        }
        Debug.Log("end while");
    }       
}