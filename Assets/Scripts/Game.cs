using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject whiteKing;
    public GameObject whiteQueen;
    public GameObject whiteRook1;
    public GameObject whiteRook2;
    public GameObject whiteKnight1;
    public GameObject whiteKnight2;
    public GameObject whiteBishop1;
    public GameObject whiteBishop2;
    public GameObject whitePawn1;
    public GameObject whitePawn2;
    public GameObject whitePawn3;
    public GameObject whitePawn4;
    public GameObject whitePawn5;
    public GameObject whitePawn6;
    public GameObject whitePawn7;
    public GameObject whitePawn8;


    public GameObject blackKing;
    public GameObject blackQueen;
    public GameObject blackRook1;
    public GameObject blackRook2;
    public GameObject blackKnight1;
    public GameObject blackKnight2;
    public GameObject blackBishop1;
    public GameObject blackBishop2;
    public GameObject blackPawn1;
    public GameObject blackPawn2;
    public GameObject blackPawn3;
    public GameObject blackPawn4;
    public GameObject blackPawn5;
    public GameObject blackPawn6;
    public GameObject blackPawn7;
    public GameObject blackPawn8;

    public int[] Square;
    public int[] testSquare;
    public GameObject[] Pieces;
    public int[] pieceValues;

    public int[] moves;

    private int[] checkTest;

    private int[] myMoves;

    private int[] squareMap;

    public string yourTurn = "White";

    public int lastWhiteKingPos = 60;
    public int whiteKingPos = 60;
    public int lastBlackKingPos = 4;
    public int blackKingPos = 4;
    public int attackedSquare = -1;

    //bottom text bottom text
    public Text bottomText;

    //turn number
    public Text moreInfo;

    public int turnNum = 1;

    //points held (negative = black has advantage, positive = white has advantage)

    public Text gameStateText;





    // Start is called before the first frame update
    void Start()
    {

        botMoves = new int[32];

        squareMap = new int[64];

        bottomText.text = "White's turn";
        moreInfo.text = "turn " + turnNum;
        gameStateText.text = "position evaluation";
        depthText.text = "Depth: " + depth;
        positionsText.text = "press b to generate a move";

        Square = new int[64];

        Pieces = new GameObject[33];
        Pieces[1] = whitePawn1;
        Pieces[2] = whitePawn2;
        Pieces[3] = whitePawn3;
        Pieces[4] = whitePawn4;
        Pieces[5] = whitePawn5;
        Pieces[6] = whitePawn6;
        Pieces[7] = whitePawn7;
        Pieces[8] = whitePawn8;
        Pieces[9] = whiteBishop1;
        Pieces[10] = whiteBishop2;
        Pieces[11] = whiteKnight1;
        Pieces[12] = whiteKnight2;
        Pieces[13] = whiteRook1;
        Pieces[14] = whiteRook2;
        Pieces[15] = whiteQueen;
        Pieces[16] = whiteKing;

        Pieces[17] = blackPawn1;
        Pieces[18] = blackPawn2;
        Pieces[19] = blackPawn3;
        Pieces[20] = blackPawn4;
        Pieces[21] = blackPawn5;
        Pieces[22] = blackPawn6;
        Pieces[23] = blackPawn7;
        Pieces[24] = blackPawn8;
        Pieces[25] = blackBishop1;
        Pieces[26] = blackBishop2;
        Pieces[27] = blackKnight1;
        Pieces[28] = blackKnight2;
        Pieces[29] = blackRook1;
        Pieces[30] = blackRook2;
        Pieces[31] = blackQueen;
        Pieces[32] = blackKing;

        pieceValues = new int[33];

        pieceValues[1] = 1;
        pieceValues[2] = 1;
        pieceValues[3] = 1;
        pieceValues[4] = 1;
        pieceValues[5] = 1;
        pieceValues[6] = 1;
        pieceValues[7] = 1;
        pieceValues[8] = 1;
        pieceValues[9] = 3;
        pieceValues[10] = 3;
        pieceValues[11] = 3;
        pieceValues[12] = 3;
        pieceValues[13] = 5;
        pieceValues[14] = 5;
        pieceValues[15] = 9;
        pieceValues[16] = 1000;

        pieceValues[17] = -1;
        pieceValues[18] = -1;
        pieceValues[19] = -1;
        pieceValues[20] = -1;
        pieceValues[21] = -1;
        pieceValues[22] = -1;
        pieceValues[23] = -1;
        pieceValues[24] = -1;
        pieceValues[25] = -3;
        pieceValues[26] = -3;
        pieceValues[27] = -3;
        pieceValues[28] = -3;
        pieceValues[29] = -5;
        pieceValues[30] = -5;
        pieceValues[31] = -9;
        pieceValues[32] = -1000;

        squareMap[0] = 0;
        squareMap[1] = 1;
        squareMap[2] = 2;
        squareMap[3] = 3;
        squareMap[4] = 3;
        squareMap[5] = 2;
        squareMap[6] = 1;
        squareMap[7] = 0;

        squareMap[8] = 0;
        squareMap[9] = 1;
        squareMap[10] = 2;
        squareMap[11] = 3;
        squareMap[12] = 3;
        squareMap[13] = 2;
        squareMap[14] = 1;
        squareMap[15] = 0;

        squareMap[16] = 1;
        squareMap[17] = 2;
        squareMap[18] = 4;
        squareMap[19] = 5;
        squareMap[20] = 5;
        squareMap[21] = 4;
        squareMap[22] = 2;
        squareMap[23] = 1;

        squareMap[24] = 1;
        squareMap[25] = 3;
        squareMap[26] = 5;
        squareMap[27] = 9;
        squareMap[28] = 9;
        squareMap[29] = 5;
        squareMap[30] = 3;
        squareMap[31] = 1;

        squareMap[32] = 1;
        squareMap[33] = 3;
        squareMap[34] = 5;
        squareMap[35] = 9;
        squareMap[36] = 9;
        squareMap[37] = 5;
        squareMap[38] = 3;
        squareMap[39] = 1;

        squareMap[40] = 1;
        squareMap[41] = 2;
        squareMap[42] = 4;
        squareMap[43] = 5;
        squareMap[44] = 5;
        squareMap[45] = 4;
        squareMap[46] = 2;
        squareMap[47] = 1;

        squareMap[48] = 0;
        squareMap[49] = 1;
        squareMap[50] = 2;
        squareMap[51] = 3;
        squareMap[52] = 3;
        squareMap[53] = 2;
        squareMap[54] = 1;
        squareMap[55] = 0;

        squareMap[56] = 0;
        squareMap[57] = 1;
        squareMap[58] = 2;
        squareMap[59] = 3;
        squareMap[60] = 3;
        squareMap[61] = 2;
        squareMap[62] = 1;
        squareMap[63] = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            
            if(yourTurn == "Black")
            {
                pickMove(0, 0, -1, -9999, 9999);
                sendingIt();
            }
            depthText.text = "depth: " + depth;
            positionsText.text = "Positions checked: " + movesChecked;
            movesChecked = 0;
            
        }
        if (Input.GetKeyDown("i"))
        {
            StartGame();
        }

        if (Input.GetKeyDown("w"))
        {
            if(yourTurn == "White")
            {
                pickMove(0,0,1, -9999, 9999);
                sendingIt();
            }
            depthText.text = "depth: " + depth;
            positionsText.text = "Positions checked: " + movesChecked;
            movesChecked = 0;
        }

        if (Input.GetKeyDown("space"))
        {

            if (yourTurn == "Black")
            {
                pickMove(0, 0, -1, -9999, 9999);
            }
            else
            {
                pickMove(0, 0, 1, -9999, 9999);
            }
            sendingIt();
            depthText.text = "depth: " + depth;
            positionsText.text = "Positions checked: " + movesChecked;
            movesChecked = 0;

        }

        if (Input.GetKeyDown("l"))
        {
            Debug.Log(blackKing.transform.position);
        }


    }

    void StartGame()
    {
        Square[0] = 29;
        Square[1] = 27;
        Square[2] = 25;
        Square[3] = 31;
        Square[4] = 32;
        Square[5] = 26;
        Square[6] = 28;
        Square[7] = 30;
        Square[8] = 17;
        Square[9] = 18;
        Square[10] = 19;
        Square[11] = 20;
        Square[12] = 21;
        Square[13] = 22;
        Square[14] = 23;
        Square[15] = 24;

        Square[63] = 14;
        Square[62] = 12;
        Square[61] = 10;
        Square[60] = 16;
        Square[59] = 15;
        Square[58] = 9;
        Square[57] = 11;
        Square[56] = 13;
        Square[55] = 8;
        Square[54] = 7;
        Square[53] = 6;
        Square[52] = 5;
        Square[51] = 4;
        Square[50] = 3;
        Square[49] = 2;
        Square[48] = 1;

        testSquare = new int[64];

        int Startcount = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Square[Startcount] > 0)
                {
                    Pieces[Square[Startcount]] = Instantiate(Pieces[Square[Startcount]], new Vector3(j + 0.5f, -i - 0.5f, -0.1f), Quaternion.identity);
                }
                Startcount++;
            }
        }
    }

    public void nextTurn()
    {
        if (yourTurn == "White")
        {
            yourTurn = "Black";

            bottomText.text = "Black's turn";
        }
        else
        {
            yourTurn = "White";

            bottomText.text = "White's turn";

            turnNum++;

            moreInfo.text = "turn " + turnNum;
        }

        gameStateText.text = "gamestate: " + evaluatePos();
    }

    public bool myTurn(string color)
    {
        if (color == yourTurn)
        {
            return true;
        }
        return false;
    }

    public void matchLists(int final)
    {
        for(int x = 0; x < 64; x++)
        {
            if(final == 1)
            {
                testSquare[x] = Square[x];
            }
            else
            {
                Square[x] = testSquare[x];
            }
            
        }
    }

    public void UpdateList(int lastPos, int newPos)
    {
        matchLists(1);

        int holdMe = Square[lastPos];
        Square[lastPos] = 0;

        if (Square[newPos] > 0)
        {

            attackedSquare = newPos;

        }
        Square[newPos] = holdMe;
        if (holdMe == 16)
        {
            whiteKingPos = newPos;
        }
        if (holdMe == 32)
        {
            blackKingPos = newPos;
        }

    }

    public (bool, bool) isAttack(int pos, int piece)
    {
        (bool, bool) myTuple = (false, false);
        if (Square[pos] > 0)
        {
            myTuple.Item1 = true;
            if(((piece < 17) && (Square[pos] < 17)) || ((piece > 16) && (Square[pos] > 16)))
            {
                myTuple.Item2 = true;
            }
        }
        return myTuple;
    }

    public bool inCheck(string team)
    {
        checkTest = new int[32];

        for(int x = 0; x < 64; x++)
        {
            if((Square[x] > 0) && ((team == "White" && Square[x] >= 17) || (team == "Black" && Square[x] < 17)))
            {
                checkTest = LegalMoves(x);
                int checkCheck = 0;
                while(checkTest[checkCheck] != 69)
                {
                    if((yourTurn == "White" && checkTest[checkCheck] == whiteKingPos) || (yourTurn == "Black" && checkTest[checkCheck] == blackKingPos))
                    {
                        return true;
                    }

                    checkCheck++;
                }
            }
        }

        return false;
    }

    public bool checkMate()
    {

        bool inCheckMate = true;
        int countMe;
        myMoves = new int[32];

        for (int x = 0; x < 64; x++)
        {
            if ((Square[x] > 0) && ((yourTurn == "White" && Square[x] < 17) || (yourTurn == "Black" && Square[x] >= 17)))
            {
                myMoves = LegalMoves(x);
                countMe = 0;
                while(myMoves[countMe] != 69)
                {
                    UpdateList(x, myMoves[countMe]);
                    if (!(inCheck(yourTurn)))
                    {
                        inCheckMate = false;
                    }

                    matchLists(0);
                    attackedSquare = -1;
                    whiteKingPos = lastWhiteKingPos;
                    blackKingPos = lastBlackKingPos;

                    countMe++;
                }
            }

        }
        return inCheckMate;

    }




    public bool gimmeMove(int lastPos, int newPos)
    {
        moves = new int[32];
        LegalMoves(lastPos);

        //first tests if it's even a legal move in the first place

        int counter = 0;
        while (moves[counter] != 69)
        {
            if (moves[counter] == -1)
            {
                continue;
            }
            if (moves[counter] == newPos)
            {

                UpdateList(lastPos, newPos); //updates the test list to the new position. Will refrain from updating the real list until checks have been tested

                break;

            }
            counter++;
        }

        if(moves[counter] == 69) {
            return false;
        }

        //next, tests if the moves puts you in check. Resets to the previous if so.

        if (inCheck(yourTurn))
        {

            matchLists(0);

            attackedSquare = -1;

            whiteKingPos = lastWhiteKingPos;
            blackKingPos = lastBlackKingPos;

            return false;
        }

        if (attackedSquare > -1)
        {
            Destroy(Pieces[testSquare[attackedSquare]]);
            attackedSquare = -1;
        }

        matchLists(1);

        lastBlackKingPos = blackKingPos;
        lastWhiteKingPos = whiteKingPos;

        nextTurn();

        if (inCheck(yourTurn))
        {
            if (checkMate())
            {
                bottomText.text = "Checkmate." + yourTurn + "loses!";
            }
        }
       

        
        return true;
    }

    //determines all the legal moves for the piece at position lastPos



    //----------------------------------------------------the long part------------------------------------------------




    //----------------------------------------------------the long part------------------------------------------------
    public int[] LegalMoves(int lastPos)
    {

        moves = new int[32];

        int column = lastPos % 8;
        int row = Mathf.FloorToInt(lastPos / 8);
        int countMoves = 0;

        int piece = Square[lastPos];

        //white pawns ----------------------------------------------------------------------------------------------------------------------------------------------------
        if (piece >= 1 && piece <= 8)
        {
            if(row != 0 && !(isAttack(lastPos - 8,Square[lastPos]).Item1))
            {
                moves[countMoves] = lastPos - 8;
                countMoves++;
            }
            

            if(row == 6 && !(isAttack(lastPos - 16, Square[lastPos]).Item1))
            {
                moves[countMoves] = lastPos - 16;
                countMoves++;
            }

            if(row != 0 && isAttack(lastPos - 7, Square[lastPos]).Item1 && !(isAttack(lastPos - 7, Square[lastPos]).Item2) && column != 7)
            {
                moves[countMoves] = lastPos - 7;
                countMoves++;
            }

            if(row != 0 && isAttack(lastPos - 9, Square[lastPos]).Item1 && !(isAttack(lastPos - 9, Square[lastPos]).Item2) && column != 0)
            {
                moves[countMoves] = lastPos - 9;
                countMoves++;
            }
        }

        //black pawns ----------------------------------------------------------------------------------------------------------------------------------------------------
        if (piece >= 17 && piece <= 24)
        {
            if (row != 7 && !(isAttack(lastPos + 8, Square[lastPos]).Item1))
            {
                moves[countMoves] = lastPos + 8;
                countMoves++;
            }

            if (row == 1 && !(isAttack(lastPos + 16, Square[lastPos]).Item1))
            {
                moves[countMoves] = lastPos + 16;
                countMoves++;
            }

            if (row != 7 && isAttack(lastPos + 7, Square[lastPos]).Item1 && !(isAttack(lastPos + 7, Square[lastPos]).Item2) && column != 0)
            {
                moves[countMoves] = lastPos + 7;
                countMoves++;
            }

            if (row != 7 && isAttack(lastPos + 9, Square[lastPos]).Item1 && !(isAttack(lastPos + 9, Square[lastPos]).Item2) && column != 7)
            {
                moves[countMoves] = lastPos + 9;
                countMoves++;
            }
        }

        //bishops ----------------------------------------------------------------------------------------------------------------------------------------------------
        if (piece == 9 || piece == 10 || piece == 25 || piece == 26)
        {
            int tempPos = lastPos;
            for(int x = 0; x < 8; x++)
            {
                
                if(!(((tempPos + 7) > 63) || ((tempPos + 7) % 8 == 7)))
                {
                    moves[countMoves] = tempPos + 7;
                    countMoves++;

                    if(isAttack(tempPos + 7, Square[tempPos]).Item1)
                    {

                        if(isAttack(tempPos + 7, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                        
                    }
                    else
                    {
                        tempPos = tempPos + 7;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (!(((tempPos + 9) > 63) || ((tempPos + 9) % 8 == 0)))
                {
                    moves[countMoves] = tempPos + 9;
                    countMoves++;
                    if (isAttack(tempPos + 9, Square[tempPos]).Item1)
                    {

                        if (isAttack(tempPos + 9, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;

                    }
                    else
                    {
                        tempPos = tempPos + 9;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (!(((tempPos - 9) < 0) || ((tempPos - 9) % 8 == 7)))
                {
                    moves[countMoves] = tempPos - 9;
                    countMoves++;
                    if (isAttack(tempPos - 9, Square[tempPos]).Item1)
                    {

                        if (isAttack(tempPos - 9, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;

                    }
                    else
                    {
                        tempPos = tempPos - 9;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (!(((tempPos - 7) < 0) || ((tempPos - 7) % 8 == 0)))
                {
                    moves[countMoves] = tempPos - 7;
                    countMoves++;
                    if (isAttack(tempPos - 7, Square[tempPos]).Item1)
                    {

                        if (isAttack(tempPos - 7, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;

                    }
                    else
                    {
                        tempPos = tempPos - 7;
                    }
                }
            }
        }

        //knights ----------------------------------------------------------------------------------------------------------------------------------------------------
        if (piece == 11 || piece == 12 || piece == 27 || piece == 28)
        {
            if(row != 0)
            {
                if (column != 6 && column != 7 && !(isAttack(lastPos - 6, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos - 6;
                    countMoves++;
                }

                if (row != 1 && column != 7 && !(isAttack(lastPos - 15, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos -15;
                    countMoves++;
                }

                if (row != 1 && column != 0 && !(isAttack(lastPos - 17, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos - 17;
                    countMoves++;
                }

                if (column != 0 && column != 1 && !(isAttack(lastPos - 10, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos - 10;
                    countMoves++;
                }
            }

            if (row != 7)
            {
                if (column != 6 && column != 7 && !(isAttack(lastPos + 10, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos + 10;
                    countMoves++;
                }

                if (column != 0 && column != 1 && !(isAttack(lastPos + 6, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos + 6;
                    countMoves++;
                }

                if (row != 6 && column != 0 && !(isAttack(lastPos + 15, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos + 15;
                    countMoves++;
                }

                if (row != 6 && column != 7 && !(isAttack(lastPos + 17, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos + 17;
                    countMoves++;
                }
            }
            
        }

        //rooks ----------------------------------------------------------------------------------------------------------------------------------------------------

        if (piece == 13 || piece == 14 || piece == 29 || piece == 30)
        {
            int tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if ((tempPos % 8) != 7)
                {
                    moves[countMoves] = tempPos + 1;
                    countMoves++;

                    if (isAttack(tempPos + 1, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos + 1, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos + 1;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if ((tempPos % 8) != 0) 
                {
                    moves[countMoves] = tempPos - 1;
                    countMoves++;
                    if (isAttack(tempPos - 1, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos - 1, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos - 1;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (Mathf.FloorToInt(tempPos/8) != 7)
                {
                    moves[countMoves] = tempPos + 8;
                    countMoves++;

                    if (isAttack(tempPos + 8, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos + 8, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos + 8;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (Mathf.FloorToInt(tempPos / 8) != 0)
                {
                    moves[countMoves] = tempPos - 8;
                    countMoves++;

                    if (isAttack(tempPos - 8, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos - 8, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos - 8;
                    }
                }
            }   
        }

        //queens ----------------------------------------------------------------------------------------------------------------------------------------------------

        if (piece == 15 || piece == 31)
        {
            int tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if ((tempPos % 8) != 7)
                {
                    moves[countMoves] = tempPos + 1;
                    countMoves++;

                    if (isAttack(tempPos + 1, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos + 1, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos + 1;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if ((tempPos % 8) != 0)
                {
                    moves[countMoves] = tempPos - 1;
                    countMoves++;
                    if (isAttack(tempPos - 1, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos - 1, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos - 1;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (Mathf.FloorToInt(tempPos / 8) != 7)
                {
                    moves[countMoves] = tempPos + 8;
                    countMoves++;

                    if (isAttack(tempPos + 8, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos + 8, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos + 8;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (Mathf.FloorToInt(tempPos / 8) != 0)
                {
                    moves[countMoves] = tempPos - 8;
                    countMoves++;

                    if (isAttack(tempPos - 8, Square[tempPos]).Item1)
                    {
                        if (isAttack(tempPos - 8, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;
                    }
                    else
                    {
                        tempPos = tempPos - 8;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (!(((tempPos + 7) > 63) || ((tempPos + 7) % 8 == 7)))
                {
                    moves[countMoves] = tempPos + 7;
                    countMoves++;

                    if (isAttack(tempPos + 7, Square[tempPos]).Item1)
                    {

                        if (isAttack(tempPos + 7, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;

                    }
                    else
                    {
                        tempPos = tempPos + 7;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (!(((tempPos + 9) > 63) || ((tempPos + 9) % 8 == 0)))
                {
                    moves[countMoves] = tempPos + 9;
                    countMoves++;
                    if (isAttack(tempPos + 9, Square[tempPos]).Item1)
                    {

                        if (isAttack(tempPos + 9, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;

                    }
                    else
                    {
                        tempPos = tempPos + 9;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (!(((tempPos - 9) < 0) || ((tempPos - 9) % 8 == 7)))
                {
                    moves[countMoves] = tempPos - 9;
                    countMoves++;
                    if (isAttack(tempPos - 9, Square[tempPos]).Item1)
                    {

                        if (isAttack(tempPos - 9, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;

                    }
                    else
                    {
                        tempPos = tempPos - 9;
                    }
                }
            }

            tempPos = lastPos;
            for (int x = 0; x < 8; x++)
            {

                if (!(((tempPos - 7) < 0) || ((tempPos - 7) % 8 == 0)))
                {
                    moves[countMoves] = tempPos - 7;
                    countMoves++;
                    if (isAttack(tempPos - 7, Square[tempPos]).Item1)
                    {

                        if (isAttack(tempPos - 7, Square[lastPos]).Item2)
                        {
                            countMoves--;

                            moves[countMoves] = 0;
                        }

                        break;

                    }
                    else
                    {
                        tempPos = tempPos - 7;
                    }
                }
            }
        }
        //kings ----------------------------------------------------------------------------------------------------------------------------------------------------

        if (piece == 16 || piece == 32)
        {
            if (column != 0)
            {

                if (row != 0 && !(isAttack(lastPos - 9, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos - 9;
                    countMoves++;
                }

                if (row != 7 && !(isAttack(lastPos + 7, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos + 7;
                    countMoves++;
                }

                if (!(isAttack(lastPos - 1, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos - 1;
                    countMoves++;
                }
            }

            if(column != 7)
            {
                if (row != 0 && !(isAttack(lastPos - 7, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos - 7;
                    countMoves++;
                }

                if (row != 7 && !(isAttack(lastPos + 9, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos + 9;
                    countMoves++;
                }

                if (!(isAttack(lastPos + 1, Square[lastPos]).Item2))
                {
                    moves[countMoves] = lastPos + 1;
                    countMoves++;
                }
            }

            if (row != 0 && !(isAttack(lastPos - 8, Square[lastPos]).Item2)) {
                moves[countMoves] = lastPos - 8;
                countMoves++;
            }

            if (row != 7 && !(isAttack(lastPos + 8, Square[lastPos]).Item2)) {
                moves[countMoves] = lastPos + 8;
                countMoves++;
            }
        }

        moves[countMoves] = 69;
        return moves;
    }

    /*______________________________________________________________________________________________________________________________________________________________________________________________________
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     *                                                                                            NOW FOR THE HARD PART
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *                                                                                  
     *______________________________________________________________________________________________________________________________________________________________________________________________________
     */


    int[] botMoves;

    public int depth = 1;
    private int layer = -1;
    private float repetitions = 1;
    private int movesChecked = 0;

    private int thePiece;
    private int theMove;

    public Text depthText;
    public Text positionsText;


    float evaluatePos()
    {
        float gameState = 0f;
        for (int x = 0; x < 64; x++)
        {
            if (Square[x] > 0)
            {
                gameState += pieceValues[Square[x]];
                if(Square[x] != 0)
                {
                    /*if(Square[x] < 17)
                    {
                        gameState += (squareMap[x] / 10f);
                    }
                    else
                    {
                        gameState -= (squareMap[x] / 10f);
                    }*/
                }
             
            }
        }
        return Mathf.Round(gameState * 10f)/10f;
    }

    void sendingIt()
    {
        Pieces[Square[thePiece]].GetComponent<Piece>().moveHere(theMove);
    }



    float pickMove(int lastPos, int newPos, int color, float alpha, float beta)
    {
        layer++;
        

        int holdMe = Square[newPos];
        Square[newPos] = Square[lastPos];

        if((color == 1) && layer != 0)
        {
            if (inCheck("White"))
            {
                Square[lastPos] = Square[newPos];
                Square[newPos] = holdMe;

                layer--;

                movesChecked++;

                return 9999;
            }
        }
        else if ((color == -1) && layer != 0)
        {
            if (inCheck("Black"))
            {
                Square[lastPos] = Square[newPos];
                Square[newPos] = holdMe;

                layer--;

                movesChecked++;

                return -9999;
            }
        }

        if (newPos != lastPos)
        {
            Square[lastPos] = 0;
        }
        
        
    
        if (layer >= depth)
        {
            float positionScore = evaluatePos();
            
            Square[lastPos] = Square[newPos];
            Square[newPos] = holdMe;
            
            layer--;

            movesChecked++;

            return positionScore;
        }

        int bestPiece = 100;
        int bestMove = 100;
        float bestScore = color * -100;

        float lastMove;

        for (int x = 0; x < 64; x++)
        {
            if ((Square[x] > 0) && ((color == 1 && Square[x] < 17) || (color == -1 && Square[x] >= 17)))
            {
                int newCount = 0;
                while(LegalMoves(x)[newCount] != 69)
                {
                    lastMove = pickMove(x, LegalMoves(x)[newCount], color * -1, alpha, beta);

                    
                    
                    /*if(color == 1)
                    {
                        alpha = Mathf.Max(alpha, lastMove);

                        if(beta <= alpha)
                        {
                            break;
                        }
                    }

                    else
                    {
                        beta = Mathf.Min(beta, lastMove);

                        if (beta <= alpha)
                        {
                            break;
                        }
                    }*/
                    
                    if(Square[x] == 16 || Square[x] == 32)
                    {
                        lastMove -= ((float)color / 2f);
                    }

                    if (((lastMove > bestScore) && (color == 1)) || ((lastMove < bestScore) && (color == -1)))
                    {
                        repetitions = 1;

                        bestPiece = x;
                        bestMove = LegalMoves(x)[newCount];
                        bestScore = lastMove;
                    }

                    else if(lastMove == bestScore)
                    {
                        repetitions++;
                        int chosen = Random.Range(0, 100);

                        if (chosen <= ((1/(repetitions)) * 100)){
                            bestPiece = x;
                            bestMove = LegalMoves(x)[newCount];
                            bestScore = lastMove;
                        }
                        
                    }
                    newCount++;
                }

                

            }

        }

        

        if (newPos != lastPos)
        {
            Square[lastPos] = Square[newPos];
            Square[newPos] = holdMe;
        }
        layer--;

        if(layer == -1)
        {
            thePiece = bestPiece;
            theMove = bestMove;
            Debug.Log("The best piece lies on square: " + bestPiece);
            Debug.Log("to the following square: " + bestMove);
        }
        return bestScore;
    }

   
    
     
}

