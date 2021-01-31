using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using GJJ.UI;
using UnityEngine;

namespace GGJ.FSM
{
    public class FinalState : State
    {
        public override void Init()
        {
        }

        public override void Enter()
        {
            CrimeData[] crimeOptions = new[]
            {
                GameManager.Instance.CorrectCrime, GameManager.Instance.FakeCrimes[0],
                GameManager.Instance.FakeCrimes[1]
            };
            Dictionary<CrimeData, string> crimeTitles = new Dictionary<CrimeData, string>();
            for (int i = 0; i < crimeOptions.Length; i++)
            {
                crimeTitles.Add(crimeOptions[i], ParseTitlesForSelections(crimeOptions[i]));
            }
            GameManager.Instance.UserInterface.SelectionUI.GetComponent<SelectionUI>().InitSelectionUI(crimeTitles);
            GameManager.Instance.UserInterface.SelectionUI.SetActive(true);
        }

        public override void Exit()
        {
            GameManager.Instance.UserInterface.SelectionUI.SetActive(false);
        }

        public override void Update()
        {
        }

        private string ParseTitlesForSelections(CrimeData crime)
        {
            return $"{ParseGenres(crime.VictimGenre)} de {ParseHairColor(crime.VictimHairColor)} asesinad{ParseGenreVerb(crime.VictimGenre)} {ParseWeapon(crime.Weapon)} en {ParsePlace(crime.Room)} por {ParseGenres(crime.CriminalGenre)} de {ParseHairColor(crime.CriminalHairColor)}".ToUpper();
        }

        private string ParseGenres(CrimeTypes.Genre genre)
        {
            switch (genre)
            {
                case CrimeTypes.Genre.Man:
                    return "Hombre";
                case CrimeTypes.Genre.Woman:
                    return "Mujer";
                default:
                    return "Unknown";
            }
        }

        private string ParseGenreVerb(CrimeTypes.Genre genre)
        {
            switch (genre)
            {
                case CrimeTypes.Genre.Man:
                    return "o";
                case CrimeTypes.Genre.Woman:
                    return "a";
                default:
                    return "e";
            }
        }

        private string ParseHairColor(CrimeTypes.HairColor hair)
        {

            switch (hair)
            {
                case CrimeTypes.HairColor.Blonde:
                    return "Pelo rubio";
                case CrimeTypes.HairColor.Black:
                    return "Pelo negro";
                case CrimeTypes.HairColor.Brown:
                    return "Pelo castaño";
                case CrimeTypes.HairColor.Red:
                    return "Pelo rojo";
                case CrimeTypes.HairColor.Orange:
                    return "Pelo naranja";
                case CrimeTypes.HairColor.Purple:
                    return "Pelo violeta";
                case CrimeTypes.HairColor.Blue:
                    return "Pelo azul";
                case CrimeTypes.HairColor.Green:
                    return "Pelo verde";
                default:
                    return "Unknown";
            }
        }

        private string ParsePlace(CrimeTypes.Rooms room)
        {
            switch (room)
            {
                case CrimeTypes.Rooms.Bathroom:
                    return "El Baño";
                case CrimeTypes.Rooms.Bedroom:
                    return "El Dormitorio";
                case CrimeTypes.Rooms.DiningRoom:
                    return "El Comedor";
                case CrimeTypes.Rooms.Hall:
                    return "El Salon de entrada";
                case CrimeTypes.Rooms.Kitchen:
                    return "La Cocina";
                case CrimeTypes.Rooms.Library:
                    return "La Biblioteca";
                case CrimeTypes.Rooms.LivingRoom:
                    return "El Salon";
                case CrimeTypes.Rooms.Office:
                    return "La Oficina";
                case CrimeTypes.Rooms.Playroom:
                    return "El Salon de juegos";
                default:
                    return "Unknown";
            }
        }

        private string ParseWeapon(CrimeTypes.Weapons weapon)
        {
            switch (weapon)
            {
                case CrimeTypes.Weapons.Knife:
                    return "con Cuchillo";
                case CrimeTypes.Weapons.Pistol:
                    return "a tiros con una Pistola";
                case CrimeTypes.Weapons.Bat:
                    return "a golpes con un bat";
                case CrimeTypes.Weapons.Poison:
                    return "con veneno";
                case CrimeTypes.Weapons.Hands:
                    return "a golpes";
                default:
                    return "Unknown";
            }
        }
    }
}
