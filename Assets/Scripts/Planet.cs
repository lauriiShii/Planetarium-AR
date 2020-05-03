using System;
using UnityEngine;

[Serializable]
public class Planet : MonoBehaviour
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public int Satellite { set; get; }
    public int Rings { set; get; }
    public double Diameter { set; get; }

    public Planet(string name, string description, string imagePath, int satellite, int rings, double diameter)
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
        Satellite = satellite;
        Rings = rings;
        Diameter = diameter;
    }
}
