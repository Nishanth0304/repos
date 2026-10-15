//Encapsulation

class Program
{
    private int accNo;
    private int password;
    public void GiveData(int accNo, int password)
    {
        this.accNo = accNo;
        this.password = password;
    }
    public int GiveAccNo()
    {
        return accNo;
    }
    public int GivePassword()
    {
        return password;
    }
}
class PrintData
{
    static void Main(string[] args)
    {
        Program p = new Program();
        p.GiveData(1234, 8888);
        Console.WriteLine(p.GiveAccNo());
        Console.WriteLine(p.GivePassword());
    }
}