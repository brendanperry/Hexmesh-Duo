using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChecker : MonoBehaviour
{
    public Animator volume;
    public Animator leaderboard;
    public Animator play;
    public Animator plane;

    public Play playScript;

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)) {
                if(hit.collider.gameObject.name == "Play") {
                    hit.collider.gameObject.GetComponent<Animator>().Play("color-play", -1, 0);
                    play.Play("fade-out");
                    volume.Play("volume-out");
                    leaderboard.Play("leaderboard-out");
                    plane.Play("rotate-plane");
                    playScript.OnClick();
                } else if(hit.collider.gameObject.name == "Volume") {
                    hit.collider.gameObject.GetComponent<Animator>().Play("volume-color", -1 , 0);
                } else if(hit.collider.gameObject.name == "Leaderboard") {
                    hit.collider.gameObject.GetComponent<Animator>().Play("leaderboard-color", -1, 0);
                }
            }
        }
    }
}
