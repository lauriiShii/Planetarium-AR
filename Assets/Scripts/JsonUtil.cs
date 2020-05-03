using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using static GameManager;

public class JsonUtil : MonoBehaviour
{
    /// <summary>
    /// Obtiene la información de los planetas a partir de una cadena serializada en JSON.
    /// </summary>
    /// <returns>Lista de Planetas</returns>
    public static List<Planet> DeserializePlanet()
    {
        // El método GetFiles no está funcionando en Android.
        //// Se declaran variables
        //List<Planet> listPlanets = new List<Planet>();

        //// Se obtienen todos los ficheros en la carpeta.
        //// Se hace de esta forma porque Android no es capaz de obtener una lista a partir de un JSON.

        //DirectoryInfo info = new DirectoryInfo($"{Application.streamingAssetsPath}/");
        //FileInfo[] fileInfo = info.GetFiles("*.json");

        //// Se recorren los ficheros encontrados
        //foreach (FileInfo file in fileInfo)
        //{
        //    string filePath = file.Directory + "\\" + file.Name;

        //    listPlanets.Add(GetPlanet(filePath).Result);
        //}

        List<Planet> listPlanets = new List<Planet>();

        // Se obtienen todos los ficheros en la carpeta.
        // Se hace de esta forma porque Android no es capaz de obtener una lista a partir de un JSON y tampoco daba resultado funciones como "GetFiles" para obtenerlos todos.
        foreach (PlanetNames planetName in (PlanetNames[])Enum.GetValues(typeof(PlanetNames)))
        {
            listPlanets.Add(GetPlanet($"{Application.streamingAssetsPath}/Text/es/{planetName}.json").Result);
        }

        return listPlanets;
    }

    /// <summary>
    /// Obtiene la información del planeta.
    /// </summary>
    /// <param name="filePath">Ruta del fichero</param>
    /// <returns>Entidad Planeta</returns>
    static async public Task<Planet> GetPlanet(string filePath)
    {

        Planet planet;
        string jsonString;

        // Se lee el JSON en función de la plataforma
        if (Application.platform == RuntimePlatform.Android)
        {
            
            using (WWW reader = new WWW(filePath)) 
            {
                while (!reader.isDone) { }
                jsonString = reader.text;
            }                
        }
        else
        {
            jsonString = File.ReadAllText(filePath);
        }

        // Se deserializa el JSON
        planet = JsonConvert.DeserializeObject<Planet>(jsonString);

        return planet;
    }
}
