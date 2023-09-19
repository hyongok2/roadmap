# Entity Framework 학습 참고 자료

| 순번 | 제목 | 링크 | 비고 |
| ---| --- | --- | --- |
| 1 | Entity Framework Best Practices by IAmTimCorey | https://youtu.be/qkJ9keBmQWo | - |
| 2 | Step by Step - Entity Framework by Les Jackson | https://youtube.com/playlist?list=PLpSmZmoBaROYOxp50yy_uewyMr5rOmx1f | - |


오라클 DB 사용하는 경우 (entity Framework에서)
providerName="Oracle.ManagedDataAccess.Client"
위 구문이 들어가야 함.
그리고 사용할땐, name 즉 아래의 경우엔 "OracleDbContext" 로 사용할 수 있음.


<connectionStrings>
    <add name="OracleDbContext" providerName="Oracle.ManagedDataAccess.Client" connectionString="User Id=oracle_user;Password=oracle_user_password;Data Source=oracle" />
</connectionStrings>

아래와 같이... name을 넣어주면 DbContext에서 자동인식
public MyDbContext() : base("OracleDbContext")
{

}
