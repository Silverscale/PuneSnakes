using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBodyPicker : MonoBehaviour, ISnakeBodyPicker
{
    [SerializeField] private TMP_Dropdown bodyDropdown;
    [SerializeField] private AvatarTypeSO[] avatarType;
    
 
    private void Start()
    {
        PopulateDropdown(avatarType, bodyDropdown);
    }

    private void PopulateDropdown(AvatarTypeSO[] avatarTypes, TMP_Dropdown bodyDropdown) {

        bodyDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> optionDatas = PrepareOptionsList(avatarTypes);
        bodyDropdown.AddOptions(optionDatas);
    }

    private List<TMP_Dropdown.OptionData> PrepareOptionsList(AvatarTypeSO[] avatarTypes) {
        var optionDatas = new List<TMP_Dropdown.OptionData>();

        foreach (var avatar in avatarTypes) {
            var option = new TMP_Dropdown.OptionData(
                avatar.name,
                avatar.sprite);
            optionDatas.Add(option);
        }

        return optionDatas;
    }

    public AvatarTypeSO GetSelectedAvatarType() {
        return avatarType[bodyDropdown.value];
    }
}
