using UnityEngine;
using UnityEngine.UI;

public class PlanetManager : MonoBehaviour
{
    public Button buttonLeft;
    public Button buttonRight;
    public Button buttonCenter;
    public Button buttonClear;
    public Text lblPlanet;
    private PlacementIndicator placementIndicaTor;
    private int numInstancePlanets;

    /// <summary>
    /// Evento que se ejecuta al instanciar su contenedor, en este caso el canvas que contiene la botonera
    /// </summary>
    public void Start()
    {

        // Instanciamos posiciones iniciales
        GameManager.PlanetPositionLeft = GameManager.ListPlanet.Count - 1;
        GameManager.PlanetPositionCenter = 0;
        GameManager.PlanetPositionRight = 1;

        // Inicializamos cantidad de planetas instaciados
        numInstancePlanets = 0;

        // Asignamos imagenes
        PositionImagePlanet(GameManager.ClicPlanet.Default);
    }

    public void Update()
    {
        GameObject planet;
        // Se vacia contador de planetas instanciados
        numInstancePlanets = 0;

        // Contamos los planetas instanciados
        foreach (GameManager.PlanetNames planetName in (GameManager.PlanetNames[])System.Enum.GetValues(typeof(GameManager.PlanetNames)))
        {
            planet = GameObject.FindGameObjectWithTag(planetName.ToString());
            if (planet != null)
            {
                numInstancePlanets++;
            }
        }

        if (numInstancePlanets > 0)
        {
            //buttonClear.enabled = true;
            buttonClear.GetComponentInChildren<Text>().color = Color.white;
        }
        else
        {
            //buttonClear.enabled = false;
            buttonClear.GetComponentInChildren<Text>().color = Color.gray;
        }
    }

    /// <summary>
    /// Evento al clicar imagen izquierda. Este ordena las imagenes de la botonera
    /// </summary>
    public void ButtonLeftClick() 
    {
        PositionImagePlanet(GameManager.ClicPlanet.Left);
    }

    /// <summary>
    /// Evento al clicar imagen derecha. Este ordena las imagenes de la botonera
    /// </summary>
    public void ButtonRightClick()
    {
        PositionImagePlanet(GameManager.ClicPlanet.Right);
    }

    /// <summary>
    /// Evento al clicar imagen central. Este instancia el objeto a mostrar en el punto donde se encuentre el cursor
    /// </summary>
    public void ButtonCenterClick()
    {
        placementIndicaTor = FindObjectOfType<PlacementIndicator>();

        // Se crea un planeta con el tag correspondiente
        GameObject planet = Resources.Load($"Prefabs/Planets/{buttonCenter.image.sprite.name}") as GameObject;

        // Se obtienen todas las instancias del planeta
        Object[] allPlanets = GameObject.FindGameObjectsWithTag(buttonCenter.image.sprite.name);

        if (allPlanets.Length > 0)
        {
            foreach (Object item in allPlanets)
            {
                // Se elimina la instancia 
                Destroy(item);
            }
        }

        // Se instancia el objeto
        Instantiate(planet,
                    placementIndicaTor.transform.position,
                    placementIndicaTor.transform.rotation);
    }

    /// <summary>
    /// Evento al clicar el botón Limpiar. Elimina todas las instancias de planetas.
    /// </summary>
    public void ButtonClear()
    {
        // Contamos los planetas instanciados
        foreach (GameManager.PlanetNames planetName in (GameManager.PlanetNames[])System.Enum.GetValues(typeof(GameManager.PlanetNames)))
        {
            // Se destruyen todos los objetos Planet
            Destroy(GameObject.FindGameObjectWithTag(planetName.ToString()));
        }

        // Se obtienen todas las instancias del planeta
        GameObject panelPlanet = GameObject.FindGameObjectWithTag(GameManager.csHOVER);

        // Se muestra el panel
        panelPlanet.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }

    /// <summary>
    /// Método que maneja el menú.
    /// </summary>
    /// <param name="clic">Enumerado que indica el botón pulsado</param>
    private void PositionImagePlanet(GameManager.ClicPlanet clic)
    {
        switch (clic)
        {
            case GameManager.ClicPlanet.Left:

                // Se mueve el menú hacia la izquierda
                GameManager.PlanetPositionCenter--;
                GameManager.PlanetPositionRight--;
                GameManager.PlanetPositionLeft--;

                // En caso de que algún botón del menú llegue al final, vuelve a la posición 0
                GameManager.PlanetPositionCenter = (GameManager.PlanetPositionCenter < 0) ? (GameManager.ListPlanet.Count - 1) : GameManager.PlanetPositionCenter;
                GameManager.PlanetPositionRight = (GameManager.PlanetPositionRight < 0) ? (GameManager.ListPlanet.Count - 1) : GameManager.PlanetPositionRight;
                GameManager.PlanetPositionLeft = (GameManager.PlanetPositionLeft < 0) ? (GameManager.ListPlanet.Count - 1) : GameManager.PlanetPositionLeft;
                break;

            case GameManager.ClicPlanet.Right:

                // Se mueve el menú hacia la derecha
                GameManager.PlanetPositionCenter++;
                GameManager.PlanetPositionRight++;
                GameManager.PlanetPositionLeft++;

                // En caso de que algún botón del menú llegue al final, vuelve a la posición 0
                GameManager.PlanetPositionCenter = (GameManager.PlanetPositionCenter > GameManager.ListPlanet.Count - 1) ? 0 : GameManager.PlanetPositionCenter;
                GameManager.PlanetPositionRight = (GameManager.PlanetPositionRight > GameManager.ListPlanet.Count - 1) ? 0 : GameManager.PlanetPositionRight;
                GameManager.PlanetPositionLeft = (GameManager.PlanetPositionLeft > GameManager.ListPlanet.Count - 1) ? 0 : GameManager.PlanetPositionLeft;
                break;
        }

        // Se cargan las imágenes correspondientes del menú
        buttonLeft.image.sprite = Resources.Load(GameManager.ListPlanet[GameManager.PlanetPositionLeft].ImagePath, typeof(Sprite)) as Sprite;
        buttonCenter.image.sprite = Resources.Load(GameManager.ListPlanet[GameManager.PlanetPositionCenter].ImagePath, typeof(Sprite)) as Sprite;
        buttonRight.image.sprite = Resources.Load(GameManager.ListPlanet[GameManager.PlanetPositionRight].ImagePath, typeof(Sprite)) as Sprite;

        // Se carga el nombre del objeto central
        lblPlanet.text = GameManager.ListPlanet[GameManager.PlanetPositionCenter].Name;       
    }
}
