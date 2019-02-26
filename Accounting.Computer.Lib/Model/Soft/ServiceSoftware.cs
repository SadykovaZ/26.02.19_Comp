using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace Accounting.Computer.Lib.Model.Soft
{
    public delegate void SendNotification(Software sw);

    public struct ServiceSoftware
    {
        PrintMessage printMessage;
        ShowError showError;
        SendNotification sendNotification;

        public void RegisterNotification(SendNotification sendNote)
        {
            this.sendNotification = sendNote;
        }
        public void RegisterMessage(PrintMessage printMessage)
        {
            this.printMessage = printMessage;
        }

        public void RegisterError(ShowError showError)
        {
            this.showError = showError;
        }
        public string DBName { get; set; }
        public void AddSoftware(Software software)
        {

            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");
                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var softwares = db.GetCollection<Software>("Software");
                    softwares.Insert(software);
                }
                if (printMessage != null)
                {
                    printMessage.Invoke("Запись добавлена успешно");
                }
                if (sendNotification!=null)
                {
                    printMessage.Invoke("Запись добавлена успешно");
                }
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }

            }
        }
    }
}
