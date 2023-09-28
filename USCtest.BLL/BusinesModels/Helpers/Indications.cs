using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.BLL.BusinesModels.Helpers
{
    public enum Indications
    {
        ColdWater, // ХВС
        HotWaterHeat, // ГВС Теплоноситель
        HotWaterThermalEnergy, // ГВС Тепловая энергия
        Electricity, // ЭЭ
        ElectricityDay, // ЭЭ день
        ElectricityNight, // ЭЭ Ночь
    }
}
