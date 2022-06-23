using RoadBook.CsharpBasic.Chapter05.Examples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadBook.CsharpBasic.Chapter05.Examples.Service
{
    // 게시판 비즈니스 로직
    internal class BoardService
    {
        Model.Board board;

        public BoardService()   // 생성자
        { 
            this.board = new Model.Board();
        }

        public BoardService(Model.Board board) // 생성자 오버로딩, 메소드 오버로딩
        {
            this.board = board;
        }

        public void Save(int number, string title, string content, string writer)
        {
            board.Number = number;
            board.Title = title;
            board.Contents = content;
            board.Writer = writer;
            board.CreateDate = DateTime.Now;
            board.UpdateDate = DateTime.Now;
        }

        public void Update(string title, string content, string writer)
        {
            board.Title = title;
            board.Contents = content;
            board.Writer = writer;
            board.UpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            board = null;

            Console.WriteLine("게시물이 삭제되었습니다.");
        }
        public void Read()
        {
            if (board != null)
            {
                Console.WriteLine("{0}번 게시물", board.Number);
                Console.WriteLine("제목 : {0}", board.Title);
                Console.WriteLine("작성일 : {0}", board.CreateDate);
                Console.WriteLine("수정일 : {0}", board.UpdateDate);
                Console.WriteLine("글쓴이 : {0}", board.Writer);
                Console.WriteLine("내용 : {0}", board.Contents);
            }
            else
            {
                Console.WriteLine("게시물이 없습니다.");
            }
        }
    }
}
