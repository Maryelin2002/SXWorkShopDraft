using GenericApi.Core.BaseModel;
using GenericApi.Core.Enums;
using System;

namespace GenericApi.Bl.Dto
{
    public class WorkShopDayDto : BaseEntityDto
    {
        public WeekDay Day { get; set; }
        public WorkShopDayMode Mode { get; set; }
        public string ModeLocation { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }

        public int WorkShopId { get; set; }
    }
}
