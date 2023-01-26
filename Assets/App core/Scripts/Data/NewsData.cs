using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsData : MonoBehaviour
{
    public static NewsData instance;

    [Header("Cards")]
    public List<CardNewsData> data;

    [Header("Details")]
    public CardNewsDetailData detailsData;

    [HideInInspector] public CardNewsData currentNewsData; 

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        data = new List<CardNewsData>();

        //ParentZoneEvents.onNewsDataLoaded += SetNewsDataList;
        //ParentZoneEvents.onNewsDetailsLoaded += SetNewsDetails;
    }
    public void SetNewsDataList(BEPosts[] response = null)
    {
        if (response == null) return;

        //data.Clear();

        for (int i = 0; i < response.Length; i++)
        {
            data.Add(new CardNewsData(response[i]));
        }

    }
    public void SetNewsDetails(BEPostContent response = null)
    {
        if (response == null) return;

        detailsData = new CardNewsDetailData(response);
    }
    private void OnDestroy()
    {
        //ParentZoneEvents.onNewsDataLoaded -= SetNewsDataList;
        //ParentZoneEvents.onNewsDetailsLoaded -= SetNewsDetails;
    }
}
