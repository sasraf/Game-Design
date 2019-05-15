using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject panelLoading, panelTransit;
    public Image loadingImage;
    public static bool isLoading;
    public Text loadingText;

    void Start()
    {
        if(isLoading == false)
        {
            StartCoroutine(WaitLoadingMenu());
        }
        else
        {
            panelLoading.SetActive(false);
        }
    }

    
    void Update()
    {
        if (loadingImage.fillAmount < 1)
        {
            loadingImage.fillAmount += 0.01f;
        }
        if (loadingImage.fillAmount >= 1)
        {
            isLoading = true;
        }
        loadingText.text = (int)(loadingImage.fillAmount * 100) + " %";
    }

    IEnumerator WaitLoadingMenu()
    {
        yield return new WaitForSeconds(3f);
        panelTransit.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        panelLoading.SetActive(false);
        yield return new WaitForSeconds(1f);
        panelTransit.SetActive(false);
    }


}
