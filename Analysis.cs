using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!\n");
        string test =
        """
        If((search(4) == 1) and (search(3) == 1))
        """;

        Analysis analysis = new Analysis(test);
        

        // funsion_start 호출로 문자열 처리
        analysis.funsion_start();  // 문자열을 처리하는 메서드


        

        
    }
}

class Analysis
{
    //search, if 변수
    public static int search_vector1; //1~4
    public static int search_result1; //0, 1
    public static int search_vector2; //1~4
    public static int search_result2; //0, 1
    public static int if_operator1; //0, 1
    public static int if_operator2; //0, 1
    public static int if_logic; //0, 1
    public static int if_manager = 0; //0, 1

    //프롬프트 결과값 분할 변수
    public static string[]? split_monjang;

    public Analysis(string monjang)
    {
        split_monjang = monjang.Split('\n');  // 줄 단위로 나누기
    }

    public void funsion_start()
    {
        foreach (string line in split_monjang)
        {
            if (if_manager == 1)
            {
                if (line[0] == '}') if_manager = 0;
                continue;
            }
            if_control(line);
            move_control(line);
            object_control(line);
        }
    }

    //move 함수 찾기
    void move_control(string line)
    {
        if (line[0] == 'f')
        {
            int a = int.Parse(line.Substring(7, line.Length - 9));
            //실행
            Console.WriteLine(line + "___f_move");
        }
        if (line[0] == 'b')
        {
            int a = int.Parse(line.Substring(7, line.Length - 9));
            //실행
            Console.WriteLine(line + "___b_move");
        }
        if (line[0] == 'l')
        {
            int a = int.Parse(line.Substring(7, line.Length - 8));
            //실행
            Console.WriteLine(line + "___l_move_"+ a);

        }
        if (line[0] == 'r')
        {
            int a = int.Parse(line.Substring(7, line.Length - 9));
            //실행
            Console.WriteLine(line + "___r_move");
        }
    }

    //if문 및 search 함수 처리
    void if_control(string line)
    {
        if (line[0] == 'I')
        {
            if (line.Length == 18)
            {
                search_vector1 = line[10] - '0';
                search_result1 = line[16] - '0';


                if (line[13] == '!')
                {
                    if_operator1 = 1; //비교연산자 -> != 일때, 값.
                }
                else if_operator1 = 0; //비교연산자 -> == 일때, 값.

                //실행 -> search를 실행하고 반환값을 받아와야 함.
                //if_manager = 실행 반환값(0-> 계속 읽을 수 있음, 1-> 해당 문장 건너뛰기)
            }
            else
            {
                List<int> positions = GetCharPositions(line, '(');
                //첫번째 search 인수
                search_vector1 = line[positions[2] + 1] - '0';
                search_result1 = line[positions[2] + 7] - '0';
                //두번째 search 인수
                search_vector2 = line[positions[4] + 1] - '0';
                search_result2 = line[positions[4] + 7] - '0';

                //비교연산자 찾기: 첫번째
                if (line[positions[2] + 4] == '!')
                {
                    if_operator1 = 1; //비교연산자 -> != 일때, 값.
                }
                else if_operator1 = 0; //비교연산자 -> == 일때, 값.
                //비교연산자 찾기: 두번째
                if (line[positions[4] + 4] == '!')
                {
                    if_operator2 = 1; //비교연산자 -> != 일때, 값.
                }
                else if_operator2 = 0; //비교연산자 -> == 일때, 값.

                //논리 연산자 찾기
                if (line[positions[2] + 10] == 'a')
                {
                    if_logic = 1; //논리연산자 -> and(&&) 일때, 값.
                }
                else if_logic = 0; //논리연산자 -> or(||) 일때, 값.

                //실행 -> search를 실행하고 반환값을 받아와야 함.
                //if_manager = 실행 반환값(0-> 계속 읽을 수 있음, 1-> 해당 문장 건너뛰기)

            }
            Console.WriteLine($"{line}__if__search__{search_vector1}_{search_result1}_{if_operator1}_{search_vector2}_{search_result2}_{if_operator2}_{if_logic}");

        }
    }
    void object_control(string line)
    {
        if (line[0] == 'h')
        {
            //실행
            Console.WriteLine(line + "__hold");

        }
        if (line[0] == 'p')
        {
            //실행
            Console.WriteLine(line + "___put");
        }
    }
    List<int> GetCharPositions(string input, char targetChar)
    {
        List<int> positions = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == targetChar)
            {
                positions.Add(i);
            }
        }

        return positions;
    }

}
