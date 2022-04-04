using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageSelecting : MonoBehaviour
{
    public Dropdown languageDropdown;

    IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        List<Dropdown.OptionData> languages = new List<Dropdown.OptionData>();
        int selected = 0;

        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Locale locale = LocalizationSettings.AvailableLocales.Locales[i];
            if(LocalizationSettings.SelectedLocale == locale)
            {
                selected = i;
            }

            languages.Add(new Dropdown.OptionData(locale.name));
        }
        languageDropdown.options = languages;

        languageDropdown.value = selected;
        languageDropdown.onValueChanged.AddListener(LocaleSelected);
    }

    static void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
