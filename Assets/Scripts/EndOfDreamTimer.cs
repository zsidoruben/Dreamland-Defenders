using System.Collections;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDreamTimer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI error;
    int startTime;
    int time;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Random.Range(60, 90);
        time = startTime;
        StartCoroutine(Minus());
    }

    IEnumerator Minus()
    {
        for (int i = 0; i <= startTime; i++)
        {
            timer.text = time.ToString();
            yield return new WaitForSeconds(1);
            time--;
        }
        if (DataBetweenScenes.SleepCount <= 5)
        {

            DataBetweenScenes.DDs += 200;
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(UpdateError("I CAN'T WAKE UP! I need to kill the monster this time."));
        }
    }

    IEnumerator UpdateError(string v)
    {
        error.text = v;
        yield return new WaitForSeconds(2);
        error.text = "";
    }
}
