﻿using System.Collections.Generic;
using System.Linq;
using Assets.Code.Effects;
using Code.Player;
using UnityEngine;

namespace Assets.Code.Game
{
    public class GameDirector : MonoBehaviour
    {
        public GameObject EndPanel;
        public DynamicLabel EndGameText;
        public EndCameraZoom Camera;

        private List<PlayerBot> playersInGame;

        void Start()
        {
            playersInGame = new List<PlayerBot>();
        }

        public void AddPlayer(PlayerBot player)
        {
            playersInGame.Add(player);
        }

        public void OnPlayerKilled(PlayerBot player)
        {
            if (playersInGame.Count(x => x.IsAlive) == 1)
            {
                foreach (var p in playersInGame)
                {
                    p.GetComponent<PlayerInput>().DisableInputFor(1f);
                }

                var winner = playersInGame.First(x => x.IsAlive);
                winner.GetComponent<EffectManager>().TriggerConfetti();
                EndPanel.SetActive(true);
                EndGameText.SetLabel(winner.PlayerId, winner.Country.ToString().ToUpper());
                winner.GetComponent<BotUIController>().PlayerKilled();
                Camera.ZoomTo(winner.transform);
            }
        }
    }
}
