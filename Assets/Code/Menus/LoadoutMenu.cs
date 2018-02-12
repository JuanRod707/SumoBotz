using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadoutMenu :MonoBehaviour
{
    public LoadoutPanel[] Panels;

    public void StartMatch(string sceneName)
    {
        GameState.Loadouts = new Loadout[4];

        for (int i = 0; i < Panels.Length; i++)
        {
            GameState.Loadouts[i] = Panels[i].GetLoadout();
        }

        SceneManager.LoadScene(sceneName);
    }
}
