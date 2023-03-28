using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float timer;
    [SerializeField] bool startTimer=false;
    [SerializeField] List<GameObject> uiElemenst;
    bool fadeBlack = false;
    // Start is called before the first frame update

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       LoadnewScene();

    }
    public void Teste()
    {
        
        // SceneManager.LoadSceneAsync("FirstGame", LoadSceneMode.Additive);
        StartCoroutine(ChangeScene());
    }



    IEnumerator LerpValue(int startingValue, float targetValue, float desiredDuration)
    {
        float timePassed = 0;
        float currentValue = startingValue;
        while(timePassed < desiredDuration)
        {
            timePassed += Time.deltaTime;
            currentValue = Mathf.Lerp(startingValue, targetValue, timePassed / desiredDuration);

            yield return null;
        }

        currentValue = targetValue;
        print(currentValue);
    }
    void LoadnewScene()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if(fadeBlack)
            {
            image.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, timer / 1));
               
                if (image.color.a == 1)
                {
                    startTimer = false;
                    timer = 0f;
                }
            }
            else
            {
                image.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, timer / 1));
                if (image.color.a == 0)
                {
                    startTimer = false;
                    timer = 0f;
                }
            }

        }
    }
    IEnumerator ChangeScene()
    {
            
        startTimer = true;
        fadeBlack = true;
        
        string sceneName = SceneManager.GetActiveScene().name;

        yield return new WaitForSeconds(1);
       var a= SceneManager.LoadSceneAsync("FirstGame", LoadSceneMode.Additive);
        
        yield return new WaitUntil(() => a.progress >= 0.9f);
        for (int i = 0; i <= uiElemenst.Count; i++)
        {
            uiElemenst[0].SetActive(false);
        }
        
        yield return new WaitForSeconds(1);
        startTimer = true;
        fadeBlack = false;
        yield return new WaitForSeconds(1);
        
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("FirstGame"));
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
