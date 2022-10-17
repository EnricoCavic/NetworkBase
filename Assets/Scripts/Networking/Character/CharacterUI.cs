using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cavic.Gameplay;

namespace Cavic.Networking.Character
{
    public class CharacterUI : MonoBehaviour
    {
        private NetworkWorldSpaceUI infoUi;

        public void CacheComponents()
        {
            if (infoUi != null) return;
            infoUi = GetComponentInChildren<NetworkWorldSpaceUI>();
            infoUi.Initialize();
        }

        public void NameDisplay(CharacterAtributes _char)
        {
            CacheComponents();
            infoUi.SetElementText($"{_char.charClass} {_char.displayName}");
        }

        public void CombatDisplay(CharacterAtributes _char)
        {
            CacheComponents();
            infoUi.SetElementText($"Dmg: {_char.atributes.damage}\nSpd: {_char.atributes.speed}");
        }

        public void DestroyDisplay()
        {
            CacheComponents();
            Destroy(infoUi.gameObject);
        }
    }
}
