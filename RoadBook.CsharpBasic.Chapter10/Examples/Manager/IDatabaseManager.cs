using RoadBook.CsharpBasic.Chapter10.Examples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 데이터베이스 관리를 위한 규약
/*
 앞장에서대로 MS-SQL만 쓰는 것이 아니라
오라클 등등 다른 DB 벤더를 이용할 수 있다.
이들을 이용하기 위해서는 SqlConnection 객체만 사용하는 것은 아니다.
예를 들어 Oracle DB에 접근하기 위해서는 'Oracle.DataAccess.dll'을 이용하여 'OracleConnection' 객체로 접근해야한다.
이 많은 DB들을 한꺼번에 관리하기 위해서는 일종의 약속이 필요하다.
'인터페이스'를 이용하여 약속의 '껍데기'를 만든다.
 */


/*
 인터페이스는 일종의 약속.
협업시 사람들 간 코드 ㅁ여명 규칙이 다를 수도 있고,
DB 별로.. 표준 문법은 같으나, 사용하는 키워드가 다른 경우가 있다. 
그래서 인터페이스라는 약속을 만들어 놓고 이 인터페이스에 맞게 클래스를 설계해 나가는 것. 
 */


namespace RoadBook.CsharpBasic.Chapter10.Examples.Manager
{
    internal class IDatabaseManager
    {
        void Open(DatabaseInfo dbInfo);
        DataTable Select(string sql);
        int Insert(string sql);
        int Update(string sql);
        int Delete(string sql);
        void Close();

        // "데이터베이스 관리는 Open, Select, Insert, Update, Delete, Close를 기본으로 하자"고 약속을 정한 것.
    }
}
