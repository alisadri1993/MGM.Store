// See https://aka.ms/new-console-template for more information











using Store.console.Model;

public class DrivedClass : BaseClass
{
    public string type;
    public DrivedClass(string type,string msg):base(msg)
    {
        this.type = type;
        var s2 = ApplicationSetting.Instance.getConfig("smsprovider");
    }
}