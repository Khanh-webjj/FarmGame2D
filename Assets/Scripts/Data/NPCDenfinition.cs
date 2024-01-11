using System;
using System.Collections.Generic;
using UnityEngine;

public enum Gender
{
    Male,Female,
    [InspectorName("Any [for romance only")]
    Any
}
[Serializable]
public class PortraitsCollection
{
    public Texture2D normal;
    public Texture2D surprised;
    public Texture2D angry;
    public Texture2D confused;
}
[CreateAssetMenu(menuName ="Data/NPC Character")]
public class NPCDenfinition : ScriptableObject
{
    public string Name = "Nameless";
    public Gender gender = Gender.Male;

    public PortraitsCollection portraits;

    public GameObject characterPrefab;

    [Header("Interaction")]
    public bool canBeRomanced;
    public Gender romancableGender;
    public List<Item> itemlikes;
    public List<Item> itemDisLike;

    [Header("Schedule WIP")]
    public string schedule;
}
