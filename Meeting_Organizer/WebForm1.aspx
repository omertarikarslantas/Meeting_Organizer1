<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Meeting_Organizer.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/main.css" rel="stylesheet" />
    <script type="text/javascript">

        function id(coming) {
            return document.getElementById(coming);
        }

        function fn_GuncelleBtn(typ, slctdId, konu, trh, sst, est, katilm) {
            if (typ == 1) {
                id("guncellebtn").style.display = 'block';
                id("kaydetbtn").style.display = 'none';
                id("selectedId").value = slctdId;
                id("txt_Subject").value = konu;
                id("txt_dt").value = trh;
                id("txt_strtdHour").value = sst;
                id("txt_endHour").value = est;
                id("txt_katilimcilar").value = katilm;
            }
            else if (typ == 0) {
                id("guncellebtn").style.display = 'none';
                id("kaydetbtn").style.display = 'block';
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="form">
                <div class="col">
                    <label class="c-label">Toplantı Konusu *</label>
                    <input name="txt_Subject" runat="server" type="text" id="txt_Subject" autocomplete="off" class="c-form-text" maxlength="350" tabindex="1" required="required" />
                </div>
                <div class="col">
                    <label class="c-label">Tarih</label>
                    <input type="date" runat="server" id="txt_dt" autocomplete="off" class="c-form-text" tabindex="2" required="required" />
                </div>
                <div class="col">
                    <label class="c-label">Başlangıç Saati</label>
                    <input type="time" runat="server" id="txt_strtdHour" autocomplete="off" class="c-form-text" tabindex="3" required="required" />
                </div>
                <div class="col">
                    <label class="c-label">Bitiş Saati</label>
                    <input type="time" runat="server" id="txt_endHour" autocomplete="off" class="c-form-text" tabindex="4" required="required" />
                </div>
                <div class="col">
                    <label class="c-label">Katılımcılar</label>
                    <textarea runat="server" id="txt_katilimcilar" class="c-form-text" tabindex="5" required="required"></textarea>
                    <input type="hidden" runat="server" id="selectedId" />
                </div>
                <div class="col">
                    <div id="kaydetbtn">
                        <asp:Button ID="btn_Kayit" Text="Kayıt" tabindex="6" runat="server" OnClick="btn_Kayit_Click" />
                    </div>
                    <div id="guncellebtn" style="display:none;">
                        <asp:Button ID="btn_guncelle" Text="Güncelle" runat="server" OnClick="btn_guncelle_Click" />
                        <asp:Button ID="btn_sil" CssClass="silbtn" Text="Toplantıyı Tamamen Sil" runat="server" OnClick="btn_sil_Click" />
                        <input type="button" onclick="fn_GuncelleBtn(0)" value="Yeni Kayıt Gir" />
                    </div>
                </div>
            </div>
            <div class="list" id="dv_list" runat="server">

            </div>
        </div>
    </form>
</body>
</html>
