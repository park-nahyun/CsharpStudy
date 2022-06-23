using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadBook.CsharpBasic.Chapter05.Examples
{
    internal class Ex010
    {
        public void Run()
        {
            // 기본 생성자 이용
            int number = 1;
            string title = "첫 번째 게시글입니다.";
            string contents = "첫 번째 공지사항입니다.";
            string writer = "운영자";

            Service.BoardService boardService = new Service.BoardService();
            boardService.Save(number, title, contents, writer);
            boardService.Read();

            Console.WriteLine("=====");
            title = "첫 번째 게시글 수정!";
            boardService.Update(title, contents, writer);
            boardService.Read();

            Console.WriteLine("=====");

            boardService.Delete();
            boardService.Read();

            Console.WriteLine();

            // 생성자 오버로딩 이용 -- board 클래스에 해당 내용들을 넣고 board를 넘긴다..
            Model.Board board = new Model.Board();
            // 원래는 RoadBook.CsharpBasic.Chapter05.Examples.Model.Board board = new 생략(); 이렇게 해야하는데
            // 여기서는 RoadBook.CsharpBasic.Chapter05.Examples까지의 namespace가 공통되므로 Model.Board로 표기가 가능하다.
            board.Number = 2;
            board.Title = "두 번째 게시글입니다.";
            board.Contents = "두 번째 공지사항입니다.";
            board.Writer = "운영자";
            board.CreateDate = DateTime.Now;
            board.UpdateDate = DateTime.Now;

            Service.BoardService anotherBoardService = new Service.BoardService(board);
            anotherBoardService.Read();
        }
    }
}

/*
 1번 게시물
제목 : 첫 번째 게시글입니다.
작성일 : 2022-06-21 오전 10:37:57             -- Save() 메소드가 실행된 시각
수정일 : 2022-06-21 오전 10:37:57             -- Save() 메소드가 실행된 시각
글쓴이 : 운영자
내용 : 첫 번째 공지사항입니다.
=====
1번 게시물
제목 : 첫 번째 게시글 수정!
작성일 : 2022-06-21 오전 10:37:57             -- Save() 메소드가 실행된 시각
수정일 : 2022-06-21 오전 10:37:57             -- Update() 메소드가 실행된 시각
글쓴이 : 운영자
내용 : 첫 번째 공지사항입니다.
=====
게시물이 삭제되었습니다.
게시물이 없습니다.

2번 게시물
제목 : 두 번째 게시글입니다.
작성일 : 2022-06-21 오전 10:37:57             -- Board 객체가 생성된 시각
수정일 : 2022-06-21 오전 10:37:57             -- Board 객체가 생성된 시각
글쓴이 : 운영자
내용 : 두 번째 공지사항입니다.
 
 */
