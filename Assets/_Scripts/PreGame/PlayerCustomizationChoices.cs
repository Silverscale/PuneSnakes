using UnityEngine;

public struct PlayerCustomizationChoices 
{
    public int playerId { get; private set; }

    public AvatarTypeSO avatarType { get; private set; }

    public Color color { get; private set; }

    public string name { get; private set; }
    //public Material material { get; private set; }

    public PlayerCustomizationChoices(int playerId, string name, AvatarTypeSO avatarType, Color color/*, Material material*/) {
        this.playerId = playerId;
        this.name = name;
        this.avatarType = avatarType;
        this.color = color;
        //this.material = material;
    }
}
