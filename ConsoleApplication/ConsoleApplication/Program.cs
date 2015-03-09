using System;
using System.Xml;

[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute : System.Attribute
{
    public readonly string Url;

    public string Topic  // Topic 是一个命名（named）参数
    {
        get
        {
            return topic;
        }
        set
        {

            topic = value;
        }
    }

    public HelpAttribute(string url)  // url 是一个定位（positional）参数
    {
        this.Url = url;
    }

    private string topic;
}
[HelpAttribute("Information on the class MyClass")]
class MyClass
{
}

namespace AttributeAppl
{
    public class Program
    {
        private static void GoThrough(XmlNode node)
        {
            Console.WriteLine("Node Name: \t" + node.Name);
            if (node.HasChildNodes)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    GoThrough(childNode);
                }
            }
            else
            {
                Console.WriteLine("Node value: \t" + node.Value);
            }


        }

        private static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string myXML =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?><myDataz xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><listS><sog><field1>123</field1><field2>a</field2><field3>b</field3></sog><sog><field1>456</field1><field2>c</field2><field3>d</field3></sog></listS></myDataz>";
            
            xmlDoc.LoadXml(myXML);
            XmlNodeList nodes = xmlDoc.ChildNodes;
            foreach (XmlNode xmlNode in nodes)
            {
                GoThrough(xmlNode);
            }
        }
    }
}