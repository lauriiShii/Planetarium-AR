using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PlanetNames { Mercurio, Venus, LaTierra, Marte, Jupiter, Saturno, Urano, Neptuno }
    public enum ClicPlanet { Default, Left, Right }

    #region "Constants"

    public const string csHOVER = "Hover";

    #endregion

    [HideInInspector]
    public static List<Planet> ListPlanet = JsonUtil.DeserializePlanet();
    public static int PlanetPositionCenter;
    public static int PlanetPositionRight;
    public static int PlanetPositionLeft;

    public static string infoPlanet = string.Empty;
    public static int infoPlanetHeigth = 500;
}
