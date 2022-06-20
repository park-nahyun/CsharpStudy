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

        public BoardService()
        { 
            this.board = new Model.Board();
        }

        public BoardService(Model.Board board)
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
            }
        }
    }
}
