using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoadBook.CsharpBasic.Chaper10.Web.Board
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseInfo dbInfo = new DatabaseInfo();
            dbInfo.Name = "RoadbookDB";
            dbInfo.Ip = "192.168.1.152";
            dbInfo.Port = 1433;
            dbInfo.UserId = "sa";
            dbInfo.UserPassword = "Arisys123$";

            MsSqlManager ms = new MsSqlManager();
            ms.Open(dbInfo);

            DataTable dt = ms.Select("SELECT IDX, TITLE, SUMMARY, CREATE_DT, CREATE_USER_NM, TAGS, LIKE_CNT, CATEGORY_IDX FROM TB_CONTENTS");

            // GridView 컴포넌트에 타겟이 될 Data를 선언해 주면 됨
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}