﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDrawerOpen : MonoBehaviour {

    public GameObject ghostDrawer;
    public GameObject[] opens;
    public GameObject[] closes;
    bool checkOpen = false;
    bool checkClose = false;

    private void Update()
    {
        CheckOpens();
        CheckCloses();

        if(CheckOpens() == true && CheckCloses() == true)
        {
            ghostDrawer.GetComponent<DrawerMove>().enabled = true;
            this.enabled = false;
        }
    }

    bool CheckOpens()
    {
        checkOpen = true;
        for(int i=0; i<opens.Length && checkOpen == true; i++)
        {
            checkOpen = opens[i].GetComponent<JudgeDrawerOpen>().drawerState;
        }

        return checkOpen;
    }

    bool CheckCloses()
    {
        checkClose = true;
        for(int i=0; i<closes.Length && checkClose == true; i++)
        {
            checkClose = !closes[i].GetComponent<JudgeDrawerOpen>().drawerState;
        }

        return checkClose;
    }
}
