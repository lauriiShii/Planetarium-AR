using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public string namePlanet;

    /// <summary>
    /// Evento que se dispara al colisionar el puntero con el objeto.
    /// </summary>
    public void OnTriggerEnter(Collider other)
    {
        // Se obtienen todas las instancias del planeta
        GameObject panelPlanet = GameObject.FindGameObjectWithTag(GameManager.csHOVER);

        // Se obtiene el texto a mostrar
        GetInformation();

        // Se actualiza el texto
        panelPlanet.GetComponentInChildren<Text>().text = GameManager.infoPlanet;

        // Se muestra el panel
        panelPlanet.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, GameManager.infoPlanetHeigth);
    }

    /// <summary>
    /// Evento que se dispara al dejar de colisionar el puntero con el objeto.
    /// </summary>
    public void OnTriggerExit(Collider other)
    {
        // Se obtienen todas las instancias del planeta
        GameObject panelPlanet = GameObject.FindGameObjectWithTag(GameManager.csHOVER);

        // Se muestra el panel
        panelPlanet.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);

        // Se vacía el texto
        panelPlanet.GetComponentInChildren<Text>().text = string.Empty;
    }

    /// <summary>
    /// Método que obtiene la información a mostrar en el panel.
    /// </summary>
    private void GetInformation()
    {
        // Se busca el objeto
        Planet planet = GameManager.ListPlanet.Find(i => i.Name.Trim() == namePlanet);

        // Se obtiene todo el texto relativo al objeto
        GameManager.infoPlanet = string.Format("Nombre: {0}\n" +
                                               "Diámetro: {1}\n" +
                                               "Satélites: {2}", planet.Name, planet.Diameter, planet.Satellite);
    }
}
