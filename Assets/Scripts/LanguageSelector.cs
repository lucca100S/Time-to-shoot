using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    private bool active = false;

    private void Awake()
    {
        int id = PlayerPrefs.GetInt("Language", 0);
        ChangeLaguage(id);
    }

    public void ChangeLaguage(int id)
    {
        if (active == true)
        {
            return;
        }
        StartCoroutine(SetLanguage(id));
    }
    
    IEnumerator SetLanguage(int id)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("Language", id);
        active = false;
    }
}
