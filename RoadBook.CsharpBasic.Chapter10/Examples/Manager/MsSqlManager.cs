using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// MS-SQL 데이터베이스를 관리하는 매니저 만들기

namespace RoadBook.CsharpBasic.Chapter10.Examples.Manager
{
    internal class MsSqlManager : IDatabaseManager // IDatabaseManager 인터페이스를 참조한다 = 약속된 메소드 Open ~ Close를 구현해야 한다.
    {
        SqlConnection connection = null;

        public void Open(DatabaseInfo dbInfo)
        { 
            string conStr = string.Format("Data Source={0},{1}; Initial Catalog={2};")
        }
    }
}
