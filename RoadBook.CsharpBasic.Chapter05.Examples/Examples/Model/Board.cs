using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
네임스페이스 : 비슷한 성격의 클래스를 '그룹화'하는 목적
똑같은 클래스명을 다른 기능으로 간주하기 위한 것
 */


// 게시판 클래스
namespace RoadBook.CsharpBasic.Chapter05.Examples.Model
{
    /// <summary>
    /// 게시판
    /// </summary>
    internal class Board
    {
        /// <summary>
        /// 게시글 번호
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 게시글 제목
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 게시글 내용
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 작성자
        /// </summary>
        public string Writer { get; set; }

        /// <summary>
        /// 작성일
        /// </summary>
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// 수정일
        /// </summary>
        public DateTime UpdateDate { get; set; }
   }
}
