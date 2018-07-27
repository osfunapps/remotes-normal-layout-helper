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
                keyNodeList[i].Attributes[XMLTypes.TYPE].Value = XMLTypes.HEX;
                keyNodesParent.AppendChild(keyNodeList[i]);
            }

            XmlNode props = document.GetElementsByTagName(XMLTypes.PROPS)[0];
            document.RemoveChild(props);
            document.Save(xmlPathStr);
            callback.OnXmlCleaned();
            
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