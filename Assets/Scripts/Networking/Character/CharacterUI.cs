using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

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

        public void NameDisplay(CharacterAtributes _atributes)
        {
            CacheComponents();
            infoUi.SetElementText($"{_atributes.charClass} {_atributes.displayName}");
        }
    }
}
