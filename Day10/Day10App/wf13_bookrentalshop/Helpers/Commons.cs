﻿namespace wf13_bookrentalshop.Helpers
{
    internal class Commons
    {
        // 모든 프로그램상에서 다 사용가능
        public static readonly string ConnString = "Server=localhost;" +
                                                   "Port=3306;" + 
                                                   "Database=bookrentalshop;" + 
                                                   "Uid=root;Pwd=12345";

        // 로그인 사용자 아이디 저장변수
        // 프로그래 전체에 이 데이터 공유
        public static string LoginID = string.Empty;
    }
}
