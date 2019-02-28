using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meeting_Organizer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List();
        }

        protected void List()
        {

            DataSet ds = new Meeting_Organizer.Toplanti().List();
            int len = 0, i = 0;
            DataRowCollection drc = ds.Tables[0].Rows;
            DataRow vn;
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            len = drc.Count;
            for (i = 0; i < len; i++)
            {
                vn = drc[i];
                string konu = vn["Konu"].ToString();
                string trh = vn["Tarih"].ToString();
                string ssat = vn["Bas_Saat"].ToString();
                string esaat = vn["Bit_Saat"].ToString();
                string katilm = vn["Katilimcilar"].ToString();

                str.Append("<div class='block'><div>Başlık: " + konu + "</div>" +
                    "<div>Tarih: " + trh + "</div>" +
                    "<div>Başlangıç Saati : " + ssat + "</div>" +
                    "<div>Bitiş Saati : " + esaat + "</div>" +
                    "<div>Katılımcılar : " + katilm + "</div>" +
                    "<div onclick=\"fn_GuncelleBtn(1," + vn["Id"] + ",'" + konu + "','" + trh + "','" + ssat + "','" + esaat + "','" + katilm + "')\">Güncelle</div>" +
                    "</div>");
            }

            dv_list.InnerHtml = str.ToString();
        }
        protected void btn_Kayit_Click(object sender, EventArgs e)
        {
            DataSet ds = new Meeting_Organizer.Toplanti().Kayit(txt_Subject.Value, txt_dt.Value, txt_strtdHour.Value, txt_endHour.Value, txt_katilimcilar.Value);
            List();
        }

        protected void btn_guncelle_Click(object sender, EventArgs e)
        {
            DataSet ds = new Meeting_Organizer.Toplanti().Guncelle(selectedId.Value, txt_Subject.Value, txt_dt.Value, txt_strtdHour.Value, txt_endHour.Value, txt_katilimcilar.Value);
            List();
        }

        protected void btn_sil_Click(object sender, EventArgs e)
        {
            DataSet ds = new Meeting_Organizer.Toplanti().Sil(selectedId.Value);
            List();
        }
    }
}