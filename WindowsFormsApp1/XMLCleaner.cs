using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using WindowsFormsApp1.program.xml;

namespace LayoutProject
{
    internal class XMLCleaner
    {
        private IXmlCleanerCallback callback;

        public XMLCleaner(IXmlCleanerCallback callback)
        {
            this.callback = callback;
        }

        public void NormalizeRemoteParams(string xmlPathStr)
        {
            XmlDocument document = LoadXmlPath(xmlPathStr);

            XmlNode keyNodesParent = document.GetElementsByTagName(XMLTypes.KEYS)[0];
            XmlNode parentCopy = keyNodesParent.Clone();
            var keyNodeList = parentCopy.ChildNodes;
            keyNodesParent.RemoveAll();
            for (int i = 0; i < parentCopy.ChildNodes.Count; i++)
            {
                if (keyNodeList[i].Attributes[XMLTypes.TYPE].Value == XMLTypes.SCREEN_ELEMENT)
                {
                    continue;
                }
                if (keyNodeList[i].Attributes[XMLTypes.TYPE].Value.Contains(XMLTypes.SCREEN_ELEMENT))
                    keyNodeList[i].Attributes[XMLTypes.TYPE].Value = StripScreenElementType(keyNodeList[i]);
                keyNodeList[i].Attributes[XMLTypes.TYPE].Value = XMLTypes.HEX;
                keyNodesParent.AppendChild(keyNodeList[i]);
            }



            RemovePropsTag(document);

            document.Save(xmlPathStr);
            callback.OnXmlCleaned();

        }

        private string StripScreenElementType(XmlNode keyNode)
        {
            var types = keyNode.Attributes[XMLTypes.TYPE].Value;
            var newTypes = Regex.Replace(types, XMLTypes.SCREEN_ELEMENT, "");
            if (newTypes.Count(x => x == '|') == 1)
                newTypes = newTypes.Replace("|", "");
            return newTypes;
        }

        private void RemovePropsTag(XmlDocument document)
        {
            XmlNode remote = document.GetElementsByTagName(XMLTypes.REMOTE)[0];
            XmlNode props = document.GetElementsByTagName(XMLTypes.PROPS)[0];
            remote.RemoveChild(props);
        }


        private XmlDocument LoadXmlPath(string xmlPath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@xmlPath);
            return document;
        }

    }

    public interface IXmlCleanerCallback
    {
        void OnXmlCleaned();

    }
}