using System.Collections.Generic;
using UnityEngine;

public class UserProgressData : MonoBehaviour
{
    public List<BEReportContent> reportContent;

    private void Awake()
    {
        GameEvents.onContentProgressFound += ContentProgressFound;

        reportContent = new List<BEReportContent>();
    }

    private void ContentProgressFound(ResponseReportContent response)
    {
        // SI no hay progreso terminamos el metodo
        if (response.data == null) return;

        if(reportContent == null) reportContent = new List<BEReportContent>();

        reportContent.Clear();

        for (int i = 0; i < response.data.Length; i++)
        {
            reportContent.Add(response.data[i]);
        }
    }
    public void SetAllUserProgress(UnitData unit)
    {
        if (reportContent == null) reportContent = new List<BEReportContent>();

        reportContent.Clear();

        for (int i = 0; i < unit.dataContent.Count; i++)
        {
            BEReportContent report = new BEReportContent();
            report.str_content_code = unit.dataContent[i].code;

            reportContent.Add(report);
        }
    }
}
