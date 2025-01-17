using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float fadeTime = 0.5f;
    public GameObject pauseMenu;
    
    public HiddenObject hiddenObject;

    public void PanelIn()
    {
        pauseMenu.transform.localScale = Vector3.zero;
        pauseMenu.transform.DOScale(1f, fadeTime).SetEase(Ease.OutFlash);
    }
    public void PanelOut()
    {
        pauseMenu.transform.localScale = Vector3.one;
        pauseMenu.transform.DOScale(0f, fadeTime).SetEase(Ease.OutFlash);
        
    }

    public void ObjectOut(GameObject gameObject)
    {
        Image colorFade = gameObject.GetComponent<Image>();
        colorFade.DOColor(Color.white, 0.1f);
        Vector2 position = new Vector2(0, 0);
        gameObject.transform.DOLocalMove(position, 1f);
        gameObject.transform.DOScale(2.5f, 1f).SetEase(Ease.OutFlash);
        
        Color customColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        colorFade.DOColor(customColor, 3.5f);
    }

    public void TransformOut(Transform transform)
    {

        transform.transform.DOScale(1.5f, 1f).SetLoops(3, LoopType.Restart).SetEase(Ease.OutFlash)
        .OnComplete(() =>
        {
            transform.transform.DOScale(1f, 1f)
            .SetEase(Ease.OutBounce);
            

        });

    }

    public void ObjectScale(GameObject gameObject)
    {
        GameObject newObject = Instantiate(gameObject, Input.mousePosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;

        newObject.transform.DOScale(1f, 0.5f).SetEase(Ease.OutFlash);
        Image colorFade = newObject.GetComponent<Image>();
        Color customColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        colorFade.DOColor(customColor, 1.5f);

        
        StartCoroutine(ObjectOut(1.5f, newObject));
        
    }


    public IEnumerator ObjectOut(float time, GameObject gameObject)
    {
        //Object Moving
       
        yield return new WaitForSeconds(time);
        Destroy(gameObject);

    }
}
