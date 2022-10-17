using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cavic.Gameplay
{

    [CreateAssetMenu(fileName = "New Character Atributes", menuName = "ScriptableObjects/CharacterAtributes")]
    public class CharacterAtributes : ScriptableObject
    {
        public string displayName;
        public Atributes atributes;
        public CharacterClass charClass;
    }

    public enum CharacterClass
    {
        BladeMaster,
        Arcanist,
        Gunner
    }

}
