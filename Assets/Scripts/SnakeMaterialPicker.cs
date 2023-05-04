using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public  class SnakeMaterialPicker : MonoBehaviour
{
    [SerializeField] private bool overrideFactoryMaterial = false;
    [SerializeField] private Material material;
    [SerializeField] private bool overridePlayerColor = false;
    [SerializeField] private Color color;
    private SpriteRenderer spriteRenderer;

    public void Construct(SnakeFactory factory, int playerID) {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(!overrideFactoryMaterial) {
            material = factory.GetMaterial(playerID);
        }
        SetMaterial(material);
        if (overridePlayerColor) {
            SetColor(color);
        } else {
            SetColor(playerID);
        }
    }

    //This takes material from SnakeFactory, and color from Player. That kinda feels wrong
    private void SetMaterial(Material material) {
        spriteRenderer.material = material;
    }

    private void SetColor(Color color) {
        spriteRenderer.color = color;
    }

    private void SetColor(int playerID) {
        SetColor(Player.GetPlayer(playerID).color);
    }
}
