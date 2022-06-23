using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 10장. 게시판 만들기 실습 - 데이터 정보를 관리하는 모델 설계

namespace RoadBook.CsharpBasic.Chapter10.Examples.Model
{
    internal class DatabaseInfo
    {
        // DB 접근을 하기 위해서는 IP, PORT, DB이름, DB접근 계정(아이디, 패스워드) 필요

        public string Ip { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
    }
}