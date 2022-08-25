using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public IntArr[] blocks;

    public GameData()
    {

    }
    public GameData(IntArr[] b)
    {

        blocks = b;
    }
}

[System.Serializable]
public class IntArr
{
    public int[] intArr;
    public IntArr(int[] _intArr)
    {
        intArr = _intArr;
    }
}

//https://game-happy-world.tistory.com/37
