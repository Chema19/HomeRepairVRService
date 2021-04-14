using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Helper
{
    public static class ConstantHelper
    {
        public static class ESTADO
        {
            public const String ACTIVO = "ACT";
            public const String INACTIVO = "INA";
        }
        public static class MESSAGE
        {
            public const String SUCCESS_MESSAGE_SAVE = "Datos guardados correctamente";
            public const String SUCCESS_MESSAGE_DELETE = "Datos eliminados correctamente";
            public const String SUCCESS_MESSAGE_CHARGE = "Datos cargados correctamento";
        }
    }
}
