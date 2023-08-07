using UnityEngine;
using System;

namespace Game.Controller
{
    public class PlayerBiomeHandler : MonoBehaviour
    {
        public event Action<Biome> NewBiomeEntered;
        public event Action BiomeExited;

        public void EnterNewBiome(Biome biome)
        {
            NewBiomeEntered?.Invoke(biome);
        }

        public void ExitBiome()
        {
            BiomeExited?.Invoke();
        }
    }
}