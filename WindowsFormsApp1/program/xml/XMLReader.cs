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

        public XMLReader(Initiator initiator)
        {
            this.xmlReaderCallback = initiator;
        }

        internal void ReadXMLPath(string xmlPath)
        {
            XmlDocument xmlDocument = LoadXmlPath(xmlPath);
            String[] xmlNodesNamesList;
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

        private string[] GetXmlNodesNamesList(XmlDocument document)
        {
            XmlNodeList keysNodesList = document.GetElementsByTagName(ATT_KEYS)[0].ChildNodes;
            int keysNodesCount = keysNodesList.Count;
            String[] namesList = new String[keysNodesCount];

            for (int i = 0; i < keysNodesCount; i++)
            {
                namesList[i] = keysNodesList[i].Attributes[XMLPreparer.ATT_NAME].Value;
            }

            return namesList;
        }


    }

    internal interface XMLReaderCallback
    {
        void OnReadEnd(XmlDocument xmlDocument, string[] xmlNodesNamesList);
    }

}
