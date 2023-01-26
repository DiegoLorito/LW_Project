using System.Collections.Generic;
using UnityEngine;

public class ReportData : MonoBehaviour
{
    public static ReportData instance;

    [Header("Progress")]
    public ReportProgressData dataProgress;
    public ReportProgressData dataProgressGeneral;

    [Header("Activity")]
    public List<CardActivityData> dataActivity;

    [Header("Rewards")]
    public List<CardRewardData> dataRewards;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        dataActivity = new List<CardActivityData>();
        dataRewards = new List<CardRewardData>();
    }
    public void SetDataProgress(ResponseProgressPerType response = null)
    {
        if(response == null)
        {
            dataProgress = null;
            dataProgressGeneral = null;

            return;
        }

        dataProgress = new ReportProgressData();

        // Establecemos el contenido total de cada seccion
        //UnitData unitData = AppServerData.instance.dataCurrentUser.GetCurUnit();
        UnitData unitData = new UnitData();
        unitData.GetTotalContent();

        dataProgress.progressGames.totalAmount = unitData.totalGames;
        dataProgress.progressVideos.totalAmount = unitData.totalVideos;

        // Establecemos el progreso de cada seccion
        if (response == null) return;

        int videos = 0;
        int episode = 0;
        int games = 0;

        for (int i = 0; i < response.data.Length; i++)
        {
            switch (response.data[i].str_type)
            {
                case "video":
                    videos = response.data[i].int_ammount;
                    break;
                case "episode":
                    videos = response.data[i].int_ammount;
                    break;
                case "game":
                    games = response.data[i].int_ammount;
                    break;

            }
        }

        dataProgress.progressGames.currentAmount = games;
        dataProgress.progressVideos.currentAmount = videos + episode;
        

    }
    public void SetDataProgressGeneral(ResponseProgressPerType response = null)
    {
        dataProgressGeneral = new ReportProgressData();

        if (response == null) return;

        int videos = 0;
        int episode = 0;
        int games = 0;

        for (int i = 0; i < response.data.Length; i++)
        {
            switch (response.data[i].str_type)
            {
                case "video":
                    videos = response.data[i].int_ammount;
                    break;
                case "episode":
                    videos = response.data[i].int_ammount;
                    break;
                case "game":
                    games = response.data[i].int_ammount;
                    break;

            }
        }

        //WorldData dataWorld = AppServerData.instance.dataCurrentUser.World;
        WorldData dataWorld = new WorldData();

        dataWorld.GetTotalContent();

        dataProgressGeneral.progressGames.currentAmount = games;
        dataProgressGeneral.progressGames.totalAmount = dataWorld.totalGames;

        dataProgressGeneral.progressVideos.currentAmount = videos + episode;
        dataProgressGeneral.progressVideos.totalAmount = dataWorld.totalVideos;
    }
    public void SetDataActivity(ResponseLastContentActivity response = null)
    {
        if (response == null)
        {
            dataActivity.Clear();
            return;
        }

        if (dataActivity == null) dataActivity = new List<CardActivityData>();

        dataActivity.Clear();
         
        //int idWorld = AppServerData.instance.GetCurrentUser().worldId;

        for (int i = 0; i < response.data.Length; i++)
        {
            //WorldData world = CatalogWorlds.instance.GetWorldById(response.data[i].id_world);
            WorldData world = new WorldData();
            UnitData unit = world.GetUnit(response.data[i].str_unit_code);
            ContentData content = unit.GetContent(response.data[i].str_content_code);

            CardActivityData card = new CardActivityData(content);

            card.world = world.Name;
            card.number = unit.index.ToString();
            card.bgColor = unit.core.colorMiddleground;

            dataActivity.Add(card);
        }
    }
    public void SetDataRewards(ResponseLastRewards response = null)
    {
        if (response == null)
        {
            dataRewards.Clear();
            return;
        }

        if (dataRewards == null) dataRewards = new List<CardRewardData>();

        dataRewards.Clear();

        for (int i = 0; i < response.data.Length; i++)
        {
            RewardData data = CatalogRewards.GetRewardByCode(response.data[i].str_rewards_code);
            data.date = response.data[i].dte_creation_date;

            CardRewardData card = new CardRewardData(data);

            dataRewards.Add(card);
        }
    }
}
