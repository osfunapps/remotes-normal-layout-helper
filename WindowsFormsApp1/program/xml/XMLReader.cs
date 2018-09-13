using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WindowsFormsApp1.program.xml;

namespace LayoutProject.program
{
    class XMLReader
    {

        //instances
        private XMLReaderCallback xmlReaderCallback;

        //finals
        public static string ATT_KEYS = "keys";

        private string SCREEN_ELEMENT = "screen_element";

        public XMLReader(Initiator initiator)
        {
            this.xmlReaderCallback = initiator;
        }

        internal void ReadXMLPath(string xmlPath)
        {
            XmlDocument xmlDocument = LoadXmlPath(xmlPath);
            List<String> xmlNodesNamesList;
            if (PathForm.RemoveWrongTvKeys)
                xmlNodesNamesList = new TvWrongKeysMaster().RemoveWrongTvKeys(xmlDocument);
            else
                xmlNodesNamesList = GetXmlNodesNamesList(xmlDocument);
            xmlReaderCallback.OnReadEnd(xmlDocument, xmlNodesNamesList);
        }


        private XmlDocument LoadXmlPath(string xmlPath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@xmlPath);
            return document;
        }

        private List<String> GetXmlNodesNamesList(XmlDocument document)
        {
            XmlNodeList keysNodesList = document.GetElementsByTagName(ATT_KEYS)[0].ChildNodes;
            int keysNodesCount = keysNodesList.Count;
            List<String> namesList = new List<string>();

            foreach (XmlNode node in keysNodesList)
            {
                if (node.Attributes[XMLPreparer.ATT_TYPE].Value.Contains(SCREEN_ELEMENT))
                {
                    namesList.Add(node.Attributes[XMLPreparer.ATT_NAME].Value);
                }
            }
            return namesList;
        }
    }

    internal interface XMLReaderCallback
    {
        void OnReadEnd(XmlDocument xmlDocument, List<string> xmlNodesNamesList);


    }

}
