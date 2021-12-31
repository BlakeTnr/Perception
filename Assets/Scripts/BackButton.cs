using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject backMenu;
    public GameObject currentMenu;

    public void goToBackMenu() {
        backMenu.SetActive(true);
        currentMenu.SetActive(false);
    }

    public void disableMenu() {
        currentMenu.SetActive(false);
    }
}
