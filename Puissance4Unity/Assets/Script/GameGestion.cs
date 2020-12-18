using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGestion : MonoBehaviour
{
    public Player PlayerOne;

    public Player PlayerTwo;

    public int PlayerTurn;

    public int[,] gameSpace = new int[7,6];

    public WinPrint TextWin;

    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                gameSpace[i, j] = 0;
            }
        }
        PlayerTurn = 1;
    }

    public void Playjeton(int culumn)
    {
        for (int row = 0; row <= 5; row++)
        {
            if (gameSpace[culumn, row] == 0)
            {
                gameSpace[culumn, row] = PlayerTurn;

                if (DetecWin(culumn, row))
                {
                    this.win();
                }
                
                switch (PlayerTurn)
                {
                    case 1 :
                        PlayerTurn = 2;
                        row = 6;
                        break;
                    case 2:
                        PlayerTurn = 1;
                        row = 6;
                        break;

                    default:
                        Debug.LogError("Error player turn");
                        break;
                }
            }
        }
    }

    private bool DetecWin(int collumn, int row)
    {
        if (this.checkColumn(collumn, row)) return true;
        if (this.checkRow(row)) return true; 
        if (this.checkDiag(collumn, row)) return true;
        return false;
    }

    private bool checkRow( int row)
    {
        int check = 0;
        for (int i = 0; i < 6; i++)
        {
            if (i >= 0)
            {
                if (gameSpace[i, row] == PlayerTurn)
                {
                    check++;
                }
                else
                {
                    check = 0;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }
        return false;
    }

    private bool checkColumn(int Collumn, int row)
    {
        int check = 0;
        for (int i = 0; i < 5; i++)
        {
            if (i >= 0)
            {
                if (gameSpace[Collumn, i] == PlayerTurn)
                {
                    check++;
                }
                else
                {
                    check = 0;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }
        return false;
    }

    private bool checkDiag(int Collumn, int row)
    {
        int check = 1;
        int checkCollumn = Collumn;
        int checkrow = row;
        for (int i = 1; i < 4; i++)
        {
            checkrow++;
            checkCollumn++;
            if (checkrow < 5 && checkCollumn < 6)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }

        check = 1;
        checkCollumn = Collumn;
        checkrow = row;

        for (int i = 1; i < 4; i++)
        {
            checkrow--;
            checkCollumn++;
            if (checkrow >= 0 && checkCollumn < 6)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }
        if (check >= 4)
        {
            return true;
        }

        check = 1;
        checkCollumn = Collumn;
        checkrow = row;

        for (int i = 1; i < 4; i++)
        {
            checkrow--;
            checkCollumn--;
            if (checkrow >= 0 && checkCollumn >= 0)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }

        check = 1;
        checkCollumn = Collumn;
        checkrow = row;

        for (int i = 1; i < 4; i++)
        {
            checkrow++;
            checkCollumn--;
            if (checkrow < 5 && checkCollumn >= 0)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }
        if (check >= 4)
        {
            return true;
        }

        return false;

    }

    private void win() 
    {

        TextWin.PrintWin("Player " + PlayerTurn);
        Debug.Log("Le joueur " + PlayerTurn + " a Gagner!");
    }
}