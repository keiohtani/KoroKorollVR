using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapaneseCharacterList {
    
    static string japaneseCharacterStringStream = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをん、。";

    static public char getRamdomCharacter()
    {
        int randomNum = Random.Range(0, japaneseCharacterStringStream.Length);
        return japaneseCharacterStringStream[randomNum];
    }

}
