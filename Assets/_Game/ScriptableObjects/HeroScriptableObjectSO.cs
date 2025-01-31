using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HeroScriptableObjectSO : ScriptableObject
{
    public Character characterPrefab;
    public Sprite sprite;
    public string nameOfCharacter;
}
