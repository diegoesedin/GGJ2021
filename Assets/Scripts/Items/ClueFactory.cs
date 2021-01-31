using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using UnityEngine;

namespace GGJ.Items
{
    public static class ClueFactory
    {
        public static Clue GetClueByType(CrimeTypes.Clues clueType)
        {
            GameObject go = UnityEngine.MonoBehaviour.Instantiate(GameManager.Instance.ItemPrefab);
            Clue clue = go.GetComponent<Clue>();
            switch (clueType)
            {
                case CrimeTypes.Clues.BloodLine:
                    break;
                case CrimeTypes.Clues.BloodWall:
                    break;
                case CrimeTypes.Clues.Scratches:
                    break;
                case CrimeTypes.Clues.Spots:
                    break;
                default:
                    break;
            }

            return clue;
        }
        public static Clue GetClueByType(CrimeTypes.Weapons weaponType)
        {
            GameObject go = UnityEngine.MonoBehaviour.Instantiate(GameManager.Instance.ItemPrefab);
            Clue clue = go.GetComponent<Clue>();
            switch (weaponType)
            {
                case CrimeTypes.Weapons.Knife:
                    break;
                case CrimeTypes.Weapons.Pistol:
                    break;
                case CrimeTypes.Weapons.Shotgun:
                    break;
                case CrimeTypes.Weapons.Hands:
                    break;
                default:
                    break;
            }

            return clue;
        }
        public static Clue GetClueByType(CrimeTypes.Genre genreVictim, CrimeTypes.HairColor hairVictim)
        {
            GameObject go = UnityEngine.MonoBehaviour.Instantiate(GameManager.Instance.ItemPrefab);
            Clue clue = go.GetComponent<Clue>();
            switch (genreVictim)
            {
                case CrimeTypes.Genre.Man:
                    break;
                case CrimeTypes.Genre.Woman:
                    break;
                default:
                    break;
            }
            switch (hairVictim)
            {
                case CrimeTypes.HairColor.Black:
                    break;
                case CrimeTypes.HairColor.Blonde:
                    break;
                case CrimeTypes.HairColor.Red:
                    break;
                default:
                    break;
            }

            return clue;
        }
    }
}
