using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GGJ.Crimes;
using GGJ.Data;
using UnityEngine;

namespace GGJ.Items
{
    public static class ClueFactory
    {
        public static Clue GetClueByType(CrimeTypes.Clues clueType)
        {
            ClueSpriteData[] clueSpriteData = Resources.LoadAll<ClueSpriteData>("SpriteData/ClueData/");
            Debug.Log($"Clues found for selection: {clueSpriteData.Length}");
            GameObject go = UnityEngine.MonoBehaviour.Instantiate(GameManager.Instance.ItemPrefab);
            Clue clue = go.GetComponent<Clue>();

            ClueSpriteData selectedClue;
            int randomSelection = 0;
            ClueSpriteData[] cluesByType = clueSpriteData.Where(data => data.clue == clueType).ToArray();
            randomSelection = UnityEngine.Random.Range(0, cluesByType.Length);
            selectedClue = cluesByType[randomSelection];

            clue.DrawSprite(selectedClue.sprite);

            /*switch (clueType)
            {
                case CrimeTypes.Clues.BloodLine:
                    ClueSpriteData[] bloodLines = clueSpriteData.Where(data => data.clue == clueType).ToArray();
                    randomSelection = UnityEngine.Random.Range(0, bloodLines.Length);
                    selectedClue = bloodLines[randomSelection];
                    break;
                case CrimeTypes.Clues.BloodWall:
                    ClueSpriteData[] bloodWalls = clueSpriteData.Where(data => data.clue == clueType).ToArray();
                    randomSelection = UnityEngine.Random.Range(0, bloodWalls.Length);
                    selectedClue = bloodWalls[randomSelection];
                    break;
                case CrimeTypes.Clues.BloodSpot:
                    ClueSpriteData[] bloodSpots = clueSpriteData.Where(data => data.clue == clueType).ToArray();
                    randomSelection = UnityEngine.Random.Range(0, bloodSpots.Length);
                    selectedClue = bloodSpots[randomSelection];
                    break;
                case CrimeTypes.Clues.BloodHand:
                    break;
                case CrimeTypes.Clues.BloodFeet:
                    break;
                case CrimeTypes.Clues.BulletsHoles:
                    break;
                case CrimeTypes.Clues.PoisonSpot:
                    break;
                default:
                    break;
            }*/

            return clue;
        }
        public static Clue GetClueByType(CrimeTypes.Weapons weaponType)
        {
            WeaponSpriteData[] weaponSpriteData = Resources.LoadAll<WeaponSpriteData>("SpriteData/WeaponData/");
            Debug.Log($"Weapons found for selection: {weaponSpriteData.Length}");
            GameObject go = UnityEngine.MonoBehaviour.Instantiate(GameManager.Instance.ItemPrefab);
            Clue clue = go.GetComponent<Clue>();

            WeaponSpriteData selectedWeapon = weaponSpriteData.First(data => data.weapon == weaponType);
            clue.DrawSprite(selectedWeapon.sprite);
            /*switch (weaponType)
            {
                case CrimeTypes.Weapons.Knife:
                    break;
                case CrimeTypes.Weapons.Pistol:
                    break;
                case CrimeTypes.Weapons.Bat:
                    break;
                case CrimeTypes.Weapons.Poison:
                    break;
                case CrimeTypes.Weapons.Hands:
                    break;
                default:
                    break;
            }*/

            return clue;
        }
        public static Clue GetClueByType(CrimeTypes.Genre genreVictim, CrimeTypes.HairColor hairVictim)
        {
            HairSpriteData[] hairData = Resources.LoadAll<HairSpriteData>("SpriteData/HairData/");
            Debug.Log($"Hairs found for selection: {hairData.Length}");
            GameObject go = UnityEngine.MonoBehaviour.Instantiate(GameManager.Instance.ItemPrefab);
            Clue clue = go.GetComponent<Clue>();

            HairSpriteData selectedHair =
                hairData.First(data => data.genre == genreVictim && data.hairColor == hairVictim);

            clue.DrawSprite(selectedHair.sprite);
            /*switch (genreVictim)
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
                case CrimeTypes.HairColor.Blonde:
                    break;
                case CrimeTypes.HairColor.Black:
                    break;
                case CrimeTypes.HairColor.Brown:
                    break;
                case CrimeTypes.HairColor.Red:
                    break;
                case CrimeTypes.HairColor.Orange:
                    break;
                case CrimeTypes.HairColor.Purple:
                    break;
                case CrimeTypes.HairColor.Blue:
                    break;
                case CrimeTypes.HairColor.Green:
                    break;
                default:
                    break;
            }*/

            return clue;
        }
    }
}
