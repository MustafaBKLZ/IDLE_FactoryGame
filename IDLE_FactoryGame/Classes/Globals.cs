using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDLE_FactoryGame

{
    public static class Globals
    {
        public static string Alert = "";
        public static string AppPath = System.Windows.Forms.Application.StartupPath;
        public static bool isLoad = false;
        public static SQLConnectionClass sql = new SQLConnectionClass();

        public static object Get_MyResource_PropValue_FromString(string PropName)
        {
            object ob = new MyResource();
            var typ = typeof(MyResource);
            var prop = typ.GetProperty(PropName);
            var propVal = prop.GetValue(ob, null);
            return propVal;
        }

        public static object Set_MyResource_PropValue_FromString(string PropName, double dd, string downup, bool isPower = false)
        {
            object ob = new MyResource();
            var typ = typeof(MyResource);
            var prop = typ.GetProperty(PropName);
            double deger = Convert.ToDouble(Get_MyResource_PropValue_FromString(PropName));

            double sonuc = 0;
            switch (downup)
            {
                case "-":
                    sonuc = deger - dd;
                    prop.SetValue(ob, sonuc, null);
                    break;
                case "+":
                    if (isPower) sonuc = dd;
                    else
                        sonuc = deger + dd;
                    prop.SetValue(ob, sonuc, null);
                    break;
            }
            return sonuc;
        }

        public static ToolTip Controls_Tooltip(string baslik, string aciklama, Control cntrl)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Active = true; // Görünsün mü?
            toolTip.ToolTipTitle = baslik; // Çıkacak Mesajın Başlığı
            toolTip.ToolTipIcon = ToolTipIcon.Info; // Çıkacak Mesajda yer alacak ıkon
            toolTip.UseFading = false; // Silinerek kaybolma ve yavaşça görünme
            toolTip.UseAnimation = false; // Animasyonlu açılış
            toolTip.IsBalloon = true; // Baloncuk şekli mi dikdörtgen mi?
            toolTip.ShowAlways = true; // her zaman göster
            toolTip.AutoPopDelay = 99999; // Mesajın açık kalma süresi
            toolTip.ReshowDelay = 1; // Mause çekildikten kaç ms sonra kaybolsun
            toolTip.InitialDelay = 1; // Mesajın açılma süresi
            toolTip.BackColor = Color.Red; // arka plan rengi
            toolTip.ForeColor = Color.White; // yazı rengi
            toolTip.SetToolTip(cntrl, aciklama); // Hangi kontrolde görünsün
            return toolTip;
        }




    }



}
