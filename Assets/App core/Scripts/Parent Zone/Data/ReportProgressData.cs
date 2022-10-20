using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReportProgressData
{
    public ReportProgressBarData progressGames;
    public ReportProgressBarData progressVideos;

    public ReportProgressBarData progressGeneral()
    {
        ReportProgressBarData data = new ReportProgressBarData();
       
        data.totalAmount = progressGames.totalAmount + progressVideos.totalAmount;
        data.currentAmount = progressGames.currentAmount + progressVideos.currentAmount;

        return data;
    }

    public ReportProgressData()
    {
        progressGames = new ReportProgressBarData();
        progressVideos = new ReportProgressBarData();
    }
}
