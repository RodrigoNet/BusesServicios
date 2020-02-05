using log4net;
using System;

namespace DAL
{
    [Serializable]
    public class CapturaExcepciones : Exception
    {
        public CapturaExcepciones(Exception e)
        {
            var log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Fatal(e.Message);
            log.Error("Error no controlado: " + e);
            log.ErrorFormat(e.StackTrace);
        }
    }
}
