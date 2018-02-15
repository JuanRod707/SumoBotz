using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.UI
{
    public class PlayerHudManager : MonoBehaviour
    {
        public PlayerHud[] Huds;

        public PlayerHud GetPlayerHud(int playerId)
        {
            return Huds.First(x => x.PlayerId == playerId);
        }
    }
}
