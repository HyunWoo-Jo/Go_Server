using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Go.Net;

public class Users : MonoBehaviour
{
    public GameObject playerObject;
    SortedDictionary<string, Player> users = new SortedDictionary<string, Player>();
    [SerializeField]
    private Player playerS;

    private void Start() {
        Net.instance.kernel.subEvent += Subscribe;
        Net.instance.kernel.cancelEvent += Cancel;
        Net.instance.kernel.positionEvent += SetPosition;
        users.Add(NetSubscribe.id, playerS);
    }

    public void Subscribe(string[] str) {
        if (NetSubscribe.id == str[0]) return;
        GameObject obj = Instantiate(playerObject);
        var player = obj.GetComponent<Player>();
        player.id = str[0];
        player.isPlayer = false;
        users.Add(str[0], player);
    }

    public void Cancel(string[] str) {
        if (NetSubscribe.id == str[0]) return;
        GameObject obj = users[str[0]].gameObject;
        users.Remove(str[0]);
        Destroy(obj);
    }

    public void SetPosition(string[] str) {
        if (NetSubscribe.id == str[0]) return;
        Debug.Log("setPosition"+str[0]);
        var player = users[str[0]];
        player.SetPosition(str);
    }
}
