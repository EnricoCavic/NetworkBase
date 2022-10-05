using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Atributes", menuName = "ScriptableObjects")]
public class CharacterAtributes : ScriptableObject
{
    public string displayName;
    public uint damage;
    public uint speed;
    public CharacterClass charClass;
}

public enum CharacterClass
{
    BladeMaster,
    Arcane,
    Gunner
}
