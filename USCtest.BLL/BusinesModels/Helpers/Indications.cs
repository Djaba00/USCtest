using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.BLL.BusinesModels.Helpers
{
    public enum Indications
    {
        ColdWather, // ХВС
        HotWatherHeat, // ГВС Теплоноситель
        HotWatherThermalEnergy, // ГВС Тепловая энергия
        Electricity, // ЭЭ
        ElectricityDay, // ЭЭ день
        ElectricityNight, // ЭЭ Ночь
    }
}
