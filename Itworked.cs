
namespace WIPCLR
{
    public static class CLRGETIP
    {

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString Hello()
        {

            string str = "It Worked";
            return (str);
        }
            
    }
}