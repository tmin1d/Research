using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;



class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!\n");
        string test =
        """
        l_move(1)
        If(search(4) == 1)
        {
        hold()
        r_move(2)
        }
        """;

        Analysis analysis = new Analysis(test);
        

        // funsion_start 호출로 문자열 처리
        analysis.funsion_start();  // 문자열을 처리하는 메서드


        

        
    }
}

class Analysis
{
    //search, if 변수
    public static int search_vector; //1~4
    public static int search_result; //0, 1
    public static int if_operator; //0, 1
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
    void move_control(string line) {
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
            int a = int.Parse(line.Substring(7, line.Length - 9));
            //실행
            Console.WriteLine(line + "___l_move");

        }
        if (line[0] == 'r')
        {
            int a = int.Parse(line.Substring(7, line.Length - 9));
            //실행
            Console.WriteLine(line + "___r_move");
        }
    }
    
    //if문 및 search 함수 처리
    void if_control(string line) {

        if (line[0] == 'I')
        {
            search_vector = line[10] - '0';
            search_result = line[16] - '0';


            if (line[13] == '!')
            {
                if_operator = 1; //비교연산자 -> != 일때, 값.
            }
            else if_operator = 0; //비교연산자 -> == 일때, 값.

            //실행 -> search를 실행하고 반환값을 받아와야 함.
            //if_manager = 실행 반환값(0-> 계속 읽을 수 있음, 1-> 해당 문장 건너뛰기)
            Console.WriteLine($"{line}__if__search__{search_vector}_{search_result}_{if_operator}");
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
}
