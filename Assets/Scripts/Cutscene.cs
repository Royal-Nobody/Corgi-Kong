using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject player;

    private Game game;

    private void Start()
    {
        game = GetComponent<Game>();
    }

    public void PlayIntroCutscene()
    {
        StartCoroutine(IntroCutscene());
    }

    IEnumerator IntroCutscene()
    {
        var vector3 = player.transform.position;
        vector3.y = player.transform.position.y + 4f;
        player.transform.position = vector3;

        game.allowSpiderSpawning = true;
        float preserveSpeed = GameParameters.spiderSpeed;
        float preserveMinimumTime = GameParameters.SpiderMinimumSpawnDelay;
        float preserveMaximumTime = GameParameters.SpiderMaximumSpawnDelay;
        GameParameters.spiderSpeed = preserveSpeed * 3;
        GameParameters.SpiderMinimumSpawnDelay = 0.2f;
        GameParameters.SpiderMaximumSpawnDelay = 0.75f;
        player.GetComponent<Animator>().SetBool("IsSpinning", true);
        player.transform.DOMoveY(player.transform.position.y - 4, 5, false)
            .SetEase(Ease.Linear);
        
        yield return new WaitForSeconds(5f);
        
        player.GetComponent<Animator>().SetBool("IsDead", true);
        player.GetComponent<Animator>().SetBool("IsSpinning", false);

        yield return new WaitForSeconds(3f);
        
        player.GetComponent<Animator>().SetBool("IsDead", false);
        GameParameters.spiderSpeed = preserveSpeed;
        GameParameters.SpiderMinimumSpawnDelay = preserveMinimumTime;
        GameParameters.SpiderMaximumSpawnDelay = preserveMaximumTime;
        game.isGameActive = true;
        game.allowSpiderSpawning = false;
    }
}
