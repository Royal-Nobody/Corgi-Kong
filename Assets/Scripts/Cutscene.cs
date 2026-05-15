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
        player.GetComponent<PlayerMovement>().TurnOffStateMachines();
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        var vector3 = player.transform.position;
        vector3.y = player.transform.position.y + 4f;
        player.transform.position = vector3;

        game.allowSpiderSpawning = true;
        float preserveSpeed = GameParameters.spiderSpeed;
        float preserveMinimumTime = GameParameters.SpiderMinimumSpawnDelay;
        float preserveMaximumTime = GameParameters.SpiderMaximumSpawnDelay;
        GameParameters.spiderSpeed = preserveSpeed * 2.75f;
        GameParameters.SpiderMinimumSpawnDelay = 0.25f;
        GameParameters.SpiderMaximumSpawnDelay = 0.75f;
        player.GetComponent<Animator>().SetFloat("Horizontal", 0f);
        player.GetComponent<Animator>().SetBool("IsClimbing", false);
        player.GetComponent<Animator>().SetBool("IsJumping", false);
        player.GetComponent<Animator>().SetBool("IsSpinning", true);
        player.transform.DOMoveY(player.transform.position.y - 3.5f, 5, false)
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
