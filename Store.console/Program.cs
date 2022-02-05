// See https://aka.ms/new-console-template for more information


var t = new DrivedClass("type","exception");


public class BaseClass
{
    public string message;
    public BaseClass()
    {

    }
    public BaseClass(string msg)
    {
        this.message = msg;
    }
}


public class DrivedClass : BaseClass
{
    public string type;
    public DrivedClass(string type,string msg):base(msg)
    {
        this.type = type;
    }
}